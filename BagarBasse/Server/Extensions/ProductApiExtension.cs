using BagarBasse.Server.Requests.ProductRequests;
using BagarBasse.Server.Services.ProductService;

namespace BagarBasse.Server.Extensions;


public static class ProductApiExtension
{
    public static IServiceCollection UseProductApi(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        return services;
    }
    public static WebApplication MapProductApi(this WebApplication app)
    {
        app.MediateGet<GetProductsRequest>("/api/product");

        app.MediateGet<GetAdminProductsRequest>("/api/product/admin");

        app.MediatePost<CreateProductRequest>("/api/product/");

        app.MediatePut<UpdateProductRequest>("/api/product/");

        app.MediateDelete<DeleteProductRequest>("/api/product/{id:int}");

        app.MediateGet<GetProductRequest>("/api/product/{id:int}");

        app.MediateGet<GetAdminProductRequest>("/api/product/admin/{id:int}");

        app.MediateGet<GetProductsByCategoryRequest>("/api/category/{categoryUrl}");

        app.MediateGet<SearchProductsRequest>("/api/search/{searchText}");

        return app;
    }
}