using BagarBasse.Server.Services.OrderService;
using BagarBasse.Shared.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace BagarBasse.Server.Extensions;

public static class OrderApiExtensions
{
    public static WebApplication MapOrderApi(this WebApplication webApplication)
    {
        webApplication.MapPost("/api/order", PlaceOrderHandler);

        webApplication.MapGet("/api/order", GetOrdersHandler);

        webApplication.MapGet("/api/order/admin", GetAdminOrdersHandler);

        webApplication.MapGet("/api/order/{orderId}", GetOrderDetailsHandler);

        return webApplication;
    }


    [Authorize]
    private static async Task<IResult> PlaceOrderHandler(IOrderService orderService, List<CartItem> cartItems)
    {
        var result = await orderService.PlaceOrderAsync(cartItems);
        return result != null ? TypedResults.Ok(result) : TypedResults.BadRequest("Cart is null or empty.");
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