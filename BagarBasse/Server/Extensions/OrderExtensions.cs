using BagarBasse.Server.Services.OrderService;
using BagarBasse.Shared.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace BagarBasse.Server.Extensions;

public static class OrderExtensions
{
    public static WebApplication MapOrderApi(this WebApplication webApplication)
    {
        webApplication.MapPost("/api/order", [Authorize] async (IOrderService orderService, List<CartItem> cartItems) =>
        {
            var result = await orderService.PlaceOrder(cartItems);
            return Results.Ok(result);
        });

        webApplication.MapGet("/api/order", async (IOrderService orderService) =>
        {
            var result = await orderService.GetOrders();
            return Results.Ok(result);
        });

        webApplication.MapGet("/api/order/{orderId}", async (IOrderService orderService, int orderId) =>
        {
            var result = await orderService.GetOrderDetails(orderId);
            return Results.Ok(result);
        });

        return webApplication;
    }
}