using BagarBasse.Server.Services.CartService;
using BagarBasse.Server.Requests.CartRequests;


namespace BagarBasse.Server.Extensions;

public static class CartApiExtension
{
    public static IServiceCollection UseCartApi(this IServiceCollection services)
    {
        services.AddScoped<ICartService, CartService>();
        return services;
    }
    public static WebApplication MapCartApi(this WebApplication app)
    {
        app.MediatePost<GetCartProductsRequest>("/api/cart/products");

        return app;
    }
}