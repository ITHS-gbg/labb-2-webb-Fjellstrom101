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
        app.MediateGet<GetUserInfoRequest>("api/userinfo");

        app.MediatePost<AddUserInfoRequest>("api/userinfo");

        app.MediatePut<UpdateUserInfoRequest>("api/userinfo");

        return app;
    }
}