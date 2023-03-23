using BagarBasse.Server.Services.OrderService;
using BagarBasse.Shared.Models;
using System.Security.Claims;
using BagarBasse.Server.Requests.OrderRequests;
using Microsoft.AspNetCore.Authorization;

namespace BagarBasse.Server.Extensions;

public static class OrderApiExtensions
{
    public static WebApplication MapOrderApi(this WebApplication app)
    {
        //app.MapPost("/api/order", PlaceOrderHandler);
        app.MediatePost<PlaceOrderRequest>("/api/order");

        //app.MapGet("/api/order", GetOrdersHandler);
        app.MediateGet<GetOrdersRequest>("/api/order");

        //app.MapGet("/api/order/admin", GetAdminOrdersHandler);
        app.MediateGet<GetAdminOrdersRequest>("/api/order/admin");
        
        //app.MapGet("/api/order/{orderId}", GetOrderDetailsHandler);
        app.MediateGet<GetOrderDetailsRequest>("/api/order/{orderId}");

        return app;
    }

}