using BagarBasse.Shared.Models;

namespace BagarBasse.Client.Services.AuthService;

public interface IAuthService
{
    Task<int> Register(UserRegister request);
    Task<HttpResponseMessage> Login(UserLogin request);
    Task<bool> ChangePassword(UserChangePassword request);
    Task<bool> IsUserAuthenticated();
}