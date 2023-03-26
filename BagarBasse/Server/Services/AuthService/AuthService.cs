using BagarBasse.DataAccess;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using BagarBasse.Shared.Models;
using BagarBasse.Server.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace BagarBasse.Server.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly StoreUnitOfWork _storeUnitOfWork;

    public AuthService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor,
        StoreUnitOfWork storeUnitOfWork)
    {
        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
        _storeUnitOfWork = storeUnitOfWork;
    }

    public async Task<IResult> RegisterAsync(User user, string password)
    {
        if (await UserExistsAsync(user.Email))
        {
            return TypedResults.Conflict("User already exists");
        }

        CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        if (! (await _storeUnitOfWork.UserRepository.Get().AnyAsync()))
        {
            user.Role = "Admin";
        }

        await _storeUnitOfWork.UserRepository.InsertAsync(user);
        await _storeUnitOfWork.SaveChangesAsync();

        return TypedResults.Ok(user.Id);
    }

    public async Task<bool> UserExistsAsync(string email)
    {
        return await _storeUnitOfWork.UserRepository.Get().AnyAsync(u => u.Email.ToLower().Equals(email.ToLower()));
    }

    public async Task<IResult> LoginAsync(string email, string password)
    {
        var user = await _storeUnitOfWork.UserRepository.Get().FirstOrDefaultAsync(u => u.Email.ToLower().Equals(email.ToLower()));


        if (user == null || !VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        {
            return TypedResults.Unauthorized();
        }
        else
        {
            return TypedResults.Ok(CreateToken(user));
        }
    }

    public async Task<IResult> ChangePasswordAsync(int userId, string newPassword)
    {
        var user = await _storeUnitOfWork.UserRepository.GetByID(userId);
        if (user == null)
        {
            return TypedResults.NotFound("User not found.");
        }

        CreatePasswordHash(newPassword, out byte[] passwordHash, out byte[] passwordSalt);

        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        await _storeUnitOfWork.SaveChangesAsync();

        return TypedResults.Ok("Password has been changed.");
    }

    private string? CreateToken(User user)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Email),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var key = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return jwt;
    }

    private bool VerifyPasswordHash(string password, byte[] userPasswordHash, byte[] userPasswordSalt)
    {
        using (var hmac = new HMACSHA512(userPasswordSalt))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(userPasswordHash);
        }
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac
                .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }

    public int GetUserId() =>
        int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
}