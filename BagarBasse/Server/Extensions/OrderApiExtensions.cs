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

        app.MapGet("/api/order/admin", GetAdminOrdersHandler);

        app.MapGet("/api/order/{orderId}", GetOrderDetailsHandler);

        return app;
    }



    [Authorize]
    private static async Task<IResult> GetOrdersHandler(IOrderService orderService)
    {
        var result = await orderService.GetOrdersAsync();
        return TypedResults.Ok(result);
    }

    [Authorize(Roles = "Admin")]
    private static async Task<IResult> GetAdminOrdersHandler(IOrderService orderService)
    {
        var result = await orderService.GetAdminOrdersAsync();
        return TypedResults.Ok(result);
    }

    [Authorize]
    private static async Task<IResult> GetOrderDetailsHandler(IOrderService orderService, int orderId)
    {
        var result = await orderService.GetOrderDetailsAsync(orderId);
        return result != null ? TypedResults.Ok(result) : TypedResults.NotFound("Order not found.");
    }
}