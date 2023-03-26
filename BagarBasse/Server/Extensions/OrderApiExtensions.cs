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
        app.MediateAuthorizedPost<PlaceOrderRequest>("/api/order", "User");

        app.MediateAuthorizedGet<GetOrdersRequest>("/api/order", "User");

        app.MediateAuthorizedGet<GetAdminOrdersRequest>("/api/order/admin", "Admin");
        
        app.MediateAuthorizedGet<GetOrderDetailsRequest>("/api/order/{orderId}", "User");

        return app;
    }

}