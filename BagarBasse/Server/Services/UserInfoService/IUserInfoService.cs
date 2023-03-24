using BagarBasse.Shared.Models;

namespace BagarBasse.Server.Services.UserInfoService;

public interface IUserInfoService
{
    Task<IResult> GetUserInfo();

    Task<IResult> AddUserInfo(UserInfo userInfo);
    Task<IResult> UpdateUserInfo(UserInfo userInfo);
}