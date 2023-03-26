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

        app.MediateAuthorizedGet<GetAdminProductsRequest>("/api/product/admin", "Admin");

        app.MediateAuthorizedPost<CreateProductRequest>("/api/product/", "Admin");

        app.MediateAuthorizedPut<UpdateProductRequest>("/api/product/", "Admin");

        app.MediateAuthorizedDelete<DeleteProductRequest>("/api/product/{id:int}", "Admin");

        app.MediateGet<GetProductRequest>("/api/product/{id:int}");

        app.MediateAuthorizedGet<GetAdminProductRequest>("/api/product/admin/{id:int}", "Admin");

        app.MediateGet<GetProductsByCategoryRequest>("/api/category/{categoryUrl}");

        app.MediateGet<SearchProductsRequest>("/api/search/{searchText}");

        return app;
    }
}