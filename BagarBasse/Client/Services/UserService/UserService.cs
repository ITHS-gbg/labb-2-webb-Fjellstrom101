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
}