using BagarBasse.Server.Services.OrderService;
using BagarBasse.Server.Requests.OrderRequests;

namespace BagarBasse.Server.Extensions;

public static class OrderApiExtensions
{
    public static IServiceCollection UseOrderApi(this IServiceCollection services)
    {
        services.AddScoped<IOrderService, OrderService>();
        return services;
    }
    public static WebApplication MapOrderApi(this WebApplication app)
    {
        app.MediatePost<PlaceOrderRequest>("/api/order");

        app.MediateGet<GetOrdersRequest>("/api/order");

        app.MediateGet<GetAdminOrdersRequest>("/api/order/admin");
        
        app.MediateGet<GetOrderDetailsRequest>("/api/order/{orderId}");

        return app;
    }

}