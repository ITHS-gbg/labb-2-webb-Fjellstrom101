using BagarBasse.Server.Requests.AuthRequests;
using BagarBasse.Server.Services.AuthService;

namespace BagarBasse.Server.Extensions;

public static class AuthApiExtensions
{
    public static IServiceCollection UseAuthApi(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        return services;
    }
    public static WebApplication MapAuthApi(this WebApplication app)
    {
        app.MediatePost<RegisterUserRequest>("/api/auth/register");
        
        app.MediatePost<LoginUserRequest>("/api/auth/login");

        app.MediateAuthorizedPost<ChangePasswordRequest>("/api/auth/change-password", "User");

        return app;
    }
}