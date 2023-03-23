using BagarBasse.Server.Requests.CartRequests;
using BagarBasse.Server.Services.CartService;
using BagarBasse.Server.Services.CategoryService;
using BagarBasse.Shared.Models;

namespace BagarBasse.Server.Extensions;

public static class CartApiExtension
{

    public static WebApplication MapCartApi(this WebApplication webApplication)
    {
        webApplication.MediatePost<GetCartProductsRequest>("/api/cart/products");

        return webApplication;
    }
}