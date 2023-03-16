using BagarBasse.Server.Services.ProductService;

namespace BagarBasse.Server.Extensions;

public static class ProductApiExtension
{
    public static WebApplication MapProductApi(this WebApplication webApplication)
    {
        webApplication.MapGet("/api/product", async (IProductService productService) =>
        {
            var result = await productService.GetProductsAsync();
            return Results.Ok(result);
        });

        webApplication.MapGet("/api/product/{id:int}", async (IProductService productService, int id) =>
        {
            var result = await productService.GetProductAsync(id);
            return Results.Ok(result);
        });

        webApplication.MapGet("/api/category/{categoryUrl}", async (IProductService productService, string categoryUrl) =>
        {
            var result = await productService.GetProductsByCategoryAsync(categoryUrl);
            return Results.Ok(result);
        });

        webApplication.MapGet("/api/search/{searchText}", async (IProductService productService, string searchText) =>
        {
            var result = await productService.SearchProducts(searchText);
            return Results.Ok(result);
        });

        return webApplication;
    }
}