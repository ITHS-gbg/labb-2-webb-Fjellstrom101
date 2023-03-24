namespace BagarBasse.Client.Services.UserService;

public interface IUserService
{
    Task<HttpResponseMessage> GetAdminUsersAsync();
}