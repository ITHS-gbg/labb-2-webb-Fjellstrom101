namespace BagarBasse.Client.Services.UserService;

public interface IUserService
{
    Task<HttpResponseMessage> GetAdminUsersAsync();
    Task<HttpResponseMessage> SearchUserByEmailAsync(string email);
}