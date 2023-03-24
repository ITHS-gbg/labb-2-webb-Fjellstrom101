using BagarBasse.Server.Requests.UserRequests;
using BagarBasse.Server.Services.UserService;

namespace BagarBasse.Server.Extensions;

public static class UserApiExtensions
{
    public static IServiceCollection UseUserApi(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        return services;
    }
    public static WebApplication MapUserApi(this WebApplication app)
    {
        app.MediateGet<GetAdminUsersRequest>("api/user/all");
        app.MediateGet<SearchUserByEmailRequest>("api/user/search/{email}");

        return app;
    }
}