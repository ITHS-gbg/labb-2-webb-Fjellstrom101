namespace BagarBasse.Server.Services.UserService;

public interface IUserService
{
    Task<IResult> GetAdminUsers();
}