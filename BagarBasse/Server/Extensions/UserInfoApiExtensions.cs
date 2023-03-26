using BagarBasse.Server.Requests.UserInfoRequests;
using BagarBasse.Server.Services.UserInfoService;
using BagarBasse.Shared.Models;

namespace BagarBasse.Server.Extensions;

public static class UserInfoApiExtensions
{
    public static IServiceCollection UseUserInfoApi(this IServiceCollection services)
    {
        services.AddScoped<IUserInfoService, UserInfoService>();
        return services;
    }
    public static WebApplication MapUserInfoApi(this WebApplication app)
    {
        app.MediateAuthorizedGet<GetUserInfoRequest>("api/userinfo", "User");

        app.MediateAuthorizedPost<AddUserInfoRequest>("api/userinfo", "User");

        app.MediateAuthorizedPut<UpdateUserInfoRequest>("api/userinfo", "User");

        return app;
    }
}