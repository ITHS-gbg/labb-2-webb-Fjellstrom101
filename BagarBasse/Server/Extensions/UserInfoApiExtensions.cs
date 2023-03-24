using BagarBasse.Server.Requests.UserInfoRequests;

namespace BagarBasse.Server.Extensions;

public static class UserInfoApiExtensions
{
    public static WebApplication MapUserInfoApi(this WebApplication app)
    {
        app.MediateGet<GetUserInfoRequest>("api/userinfo");

        app.MediatePost<AddUserInfoRequest>("api/userinfo");

        app.MediatePut<UpdateUserInfoRequest>("api/userinfo");

        return app;
    }
}