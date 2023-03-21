using BagarBasse.Server.Services.CartService;
using BagarBasse.Server.Services.CategoryService;
using BagarBasse.Shared.Models;

namespace BagarBasse.Server.Extensions;

public static class CartApiExtension
{
    public static WebApplication MapCartApi(this WebApplication webApplication)
    {
        webApplication.MapPost("/api/cart/products", GetCartProductsHandler);

        return webApplication;
    }

    public static async Task<IResult> GetCartProductsHandler(ICartService cartService, List<CartItem> cartItems)
    {
        var result = await cartService.GetCartProductsAsync(cartItems);
        return Results.Ok(result);
    }
}