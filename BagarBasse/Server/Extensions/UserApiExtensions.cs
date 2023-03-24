using BagarBasse.Server.Requests.UserRequests;

namespace BagarBasse.Server.Extensions;

public static class UserApiExtensions
{
    public static WebApplication MapUserApi(this WebApplication app)
    {
        app.MediateGet<GetAdminUsersRequest>("api/user/all");

        return app;
    }
}