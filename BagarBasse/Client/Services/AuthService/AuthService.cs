using System.Net.Http.Json;
using BagarBasse.Shared.Models;
using Microsoft.AspNetCore.Components.Authorization;

namespace BagarBasse.Client.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly HttpClient _http;
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public AuthService(HttpClient http, AuthenticationStateProvider authenticationStateProvider)
    {
        _http = http;
        _authenticationStateProvider = authenticationStateProvider;
    }
    public async Task<HttpResponseMessage> Register(UserRegister request)
    {
        var response = await _http.PostAsJsonAsync("api/auth/register", request);
        return response;
    }

    public async Task<HttpResponseMessage> Login(UserLogin request)
    {
        var response = await _http.PostAsJsonAsync("api/auth/login", request);
        return response;
    }

    public async Task<HttpResponseMessage> ChangePassword(UserChangePassword request)
    {
        var result = await _http.PostAsJsonAsync("api/auth/change-password", request.Password);
        return result;
    }

    public async Task<bool> IsUserAuthenticated()
    {
        return (await _authenticationStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
    }
}