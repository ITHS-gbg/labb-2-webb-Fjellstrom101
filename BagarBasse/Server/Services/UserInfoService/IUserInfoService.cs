using BagarBasse.Shared.Models;

namespace BagarBasse.Server.Services.UserInfoService;

public interface IUserInfoService
{
    Task<IResult> GetUserInfoAsync();

    Task<IResult> AddUserInfoAsync(UserInfo userInfo);
    Task<IResult> UpdateUserInfoAsync(UserInfo userInfo);
}