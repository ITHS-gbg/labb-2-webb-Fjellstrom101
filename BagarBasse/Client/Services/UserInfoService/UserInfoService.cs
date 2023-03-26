using BagarBasse.Shared.Models;
using System.Net.Http.Json;

namespace BagarBasse.Client.Services.UserInfoService;

public class UserInfoService : IUserInfoService
{
    private readonly HttpClient _http;

    public UserInfoService(HttpClient http)
    {
        _http = http;
    }
    public async Task<HttpResponseMessage> GetUserInfo()
    {
        var response = await _http.GetAsync("api/userinfo");
        return response;
    }

    public async Task<HttpResponseMessage> AddUserInfo(UserInfo userInfo)
    {
        var response = await _http.PostAsJsonAsync("api/userinfo", userInfo);
        return response;
    }
    public async Task<HttpResponseMessage> UpdateUserInfo(UserInfo userInfo)
    {
        var response = await _http.PutAsJsonAsync("api/userinfo", userInfo);
        return response;
    }
}