﻿using BagarBasse.Server.Requests.AuthRequests;
using BagarBasse.Server.Requests.CartRequests;

namespace BagarBasse.Server.Extensions;

public static class AuthApiExtensions
{
    public static WebApplication MapAuthApi(this WebApplication app)
    {
        app.MediatePost<RegisterUserRequest>("/api/auth/register");
        
        app.MediatePost<LoginUserRequest>("/api/auth/login");

        app.MediatePost<ChangePasswordRequest>("/api/auth/change-password");

        return app;
    }
}