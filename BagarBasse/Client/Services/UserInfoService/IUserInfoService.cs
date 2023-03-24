using System.Net;
using BagarBasse.Shared.Models;

namespace BagarBasse.Client.Services.UserInfoService;

public interface IUserInfoService
{
    Task<HttpResponseMessage> GetUserInfo();
    Task<HttpResponseMessage> AddUserInfo(UserInfo userInfo);
    Task<HttpResponseMessage> UpdateUserInfo(UserInfo userInfo);
}