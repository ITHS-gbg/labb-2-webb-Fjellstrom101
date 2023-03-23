using BagarBasse.Shared.Models;

namespace BagarBasse.Server.Services.AuthService;

public interface IAuthService
{
    Task<IResult> Register(User user, string password);
    Task<bool> UserExists(string email);
    Task<IResult> Login(string email, string password);
    Task<IResult> ChangePassword(int userId, string newPassword);

    int GetUserId();
    string GetUserEmail();

    Task<User> GetUserByEmail(string email);
}