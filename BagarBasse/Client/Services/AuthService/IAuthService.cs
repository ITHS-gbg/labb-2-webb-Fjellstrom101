using BagarBasse.Shared.Models;

namespace BagarBasse.Client.Services.AuthService;

public interface IAuthService
{
    Task<HttpResponseMessage> Register(UserRegister request);
    Task<HttpResponseMessage> Login(UserLogin request);
    Task<HttpResponseMessage> ChangePassword(UserChangePassword request);
    Task<bool> IsUserAuthenticated();
}