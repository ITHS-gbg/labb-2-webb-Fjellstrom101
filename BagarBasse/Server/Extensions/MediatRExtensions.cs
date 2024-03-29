﻿using BagarBasse.Server.Requests;
using MediatR;

namespace BagarBasse.Server.Extensions;

public static class MediatRExtensions
{
    public static WebApplication MediateGet<TRequest>(this WebApplication app, string template)
        where TRequest : IHttpRequest
    {
        app.MapGet(template,
            async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request));
        return app;
    }
    public static WebApplication MediatePost<TRequest>(this WebApplication app, string template)
        where TRequest : IHttpRequest
    {
        app.MapPost(template,
            async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request));
        return app;
    }
    public static WebApplication MediatePut<TRequest>(this WebApplication app, string template)
        where TRequest : IHttpRequest
    {
        app.MapPut(template,
            async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request));
        return app;
    }
    public static WebApplication MediateDelete<TRequest>(this WebApplication app, string template)
        where TRequest : IHttpRequest
    {
        app.MapDelete(template,
            async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request));
        return app;
    }
    

    //Authorized

    public static WebApplication MediateAuthorizedGet<TRequest>(this WebApplication app, string template, string policy)
        where TRequest : IHttpRequest
    {
        app.MapGet(template,
                async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request))
            .RequireAuthorization(policy);
        return app;
    }
    public static WebApplication MediateAuthorizedPost<TRequest>(this WebApplication app, string template, string policy)
        where TRequest : IHttpRequest
    {
        app.MapPost(template,
                async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request))
            .RequireAuthorization(policy);
        return app;
    }
    public static WebApplication MediateAuthorizedPut<TRequest>(this WebApplication app, string template, string policy)
        where TRequest : IHttpRequest
    {
        app.MapPut(template,
                async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request))
            .RequireAuthorization(policy);
        return app;
    }
    public static WebApplication MediateAuthorizedDelete<TRequest>(this WebApplication app, string template, string policy)
        where TRequest : IHttpRequest
    {
        app.MapDelete(template,
                async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request))
            .RequireAuthorization(policy);
        return app;
    }
}