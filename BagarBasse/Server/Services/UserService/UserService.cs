using BagarBasse.DataAccess;
using BagarBasse.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BagarBasse.Server.Services.UserService;

public class UserService : IUserService
{
    private readonly StoreUnitOfWork _storeUnitOfWork;

    public UserService(StoreUnitOfWork storeUnitOfWork)
    {
        _storeUnitOfWork = storeUnitOfWork;
    }
    public async Task<IResult> GetAdminUsersAsync()
    {
        var result = new List<UserDto>();

        await _storeUnitOfWork.UserRepository.Get()
            .Include(u => u.UserInfo)
            .ForEachAsync(u => result.Add(new UserDto
            {
                Id = u.Id,
                Email = u.Email,
                Role = u.Role,
                UserInfo = u.UserInfo,
                DateCreated = u.DateCreated
            }));
        if(result.Any())
            return TypedResults.Ok(result);

        return TypedResults.NoContent();
    }

    public async Task<IResult> SearchUserByEmailAsync(string email)
    {
        var users = _storeUnitOfWork.UserRepository.Get()
            .Where(u => u.Email.ToLower().Contains(email.ToLower()))
            .Include(u => u.UserInfo);

        var returnList = await users.Select(u => new UserDto
        {
            Id = u.Id,
            Email = u.Email,
            Role = u.Role,
            UserInfo = u.UserInfo,
            DateCreated = u.DateCreated
        }).ToListAsync();

        if (users.Any())
            return TypedResults.Ok(returnList);

        return TypedResults.NoContent();
    }
}