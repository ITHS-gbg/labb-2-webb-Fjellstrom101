using BagarBasse.Shared.Models;

namespace BagarBasse.Server.Services.AuthService;

public interface IAuthService
{
    Task<IResult> RegisterAsync(User user, string password);
    Task<bool> UserExistsAsync(string email);
    Task<IResult> LoginAsync(string email, string password);
    Task<IResult> ChangePasswordAsync(int userId, string newPassword);
    int GetUserId();
}