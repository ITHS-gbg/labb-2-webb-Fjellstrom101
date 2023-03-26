namespace BagarBasse.Server.Services.UserService;

public interface IUserService
{
    Task<IResult> GetAdminUsersAsync();
    Task<IResult> SearchUserByEmailAsync(string email);
}