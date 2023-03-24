using System.Net.Http.Json;

namespace BagarBasse.Client.Services.UserService;

public class UserService : IUserService
{
    private readonly HttpClient _http;

    public UserService(HttpClient http)
    {
        _http = http;
    }
    public async Task<HttpResponseMessage> GetAdminUsersAsync()
    {
        return await _http.GetAsync("api/user/all");
    }

    public async Task<HttpResponseMessage> SearchUserByEmailAsync(string email)
    {
        return await _http.GetAsync($"api/user/search/{email}");
    }
}