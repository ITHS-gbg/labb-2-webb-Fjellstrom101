using BagarBasse.Server.Services.ProductService;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using BagarBasse.Shared.Models;

namespace BagarBasse.Server.Extensions;

public static class ProductApiExtension
{
    public static WebApplication MapProductApi(this WebApplication webApplication)
    {
        webApplication.MapGet("/api/product", GetProductsHandler);

        webApplication.MapGet("/api/product/admin", GetAdminProductsHandler);

        webApplication.MapPost("/api/product/", CreateProductHandler);

        webApplication.MapPut("/api/product/", UpdateProductHandler);

        webApplication.MapDelete("/api/product/{id:int}", DeleteProductHandler);

        webApplication.MapGet("/api/product/{id:int}", GetProductHandler);

        webApplication.MapGet("/api/category/{categoryUrl}", GetProductsByCategoryHandler);

        webApplication.MapGet("/api/search/{searchText}", SearchProductsHandler);

        return webApplication;
    }



    private static async Task<IResult> GetProductsHandler(IProductService productService)
    {
        var result = await productService.GetProductsAsync();
        return TypedResults.Ok(result);
    }

    [Authorize(Roles = "Admin")]
    private static async Task<IResult> GetAdminProductsHandler(IProductService productService)
    {
        var result = await productService.GetAdminProductsAsync();
        return TypedResults.Ok(result);
    }

    [Authorize(Roles = "Admin")]
    private static async Task<IResult> CreateProductHandler(IProductService productService, Product product)
    {
        var result = await productService.CreateProductAsync(product);
        return TypedResults.Ok(result);
    }

    [Authorize(Roles = "Admin")]
    private static async Task<IResult> UpdateProductHandler(IProductService productService, Product product)
    {
        var result = await productService.UpdateProductAsync(product);
        return result != null ? TypedResults.Ok(result) : TypedResults.NotFound("Product not found");
    }

    [Authorize(Roles = "Admin")]
    private static async Task<IResult> DeleteProductHandler(IProductService productService, int id)
    {
        var result = await productService.DeleteProductAsync(id);
        return result ? TypedResults.Ok(result) : TypedResults.NotFound("Product not found");
    }

    private static async Task<IResult> GetProductHandler(IProductService productService, int id)
    {
        var result = await productService.GetProductAsync(id);
        return result != null
            ? TypedResults.Ok(result)
            : TypedResults.NotFound("Sorry, but this product does not exist.");
    }

    private static async Task<IResult> GetProductsByCategoryHandler(IProductService productService, string categoryUrl)
    {
        var result = await productService.GetProductsByCategoryAsync(categoryUrl);
        return TypedResults.Ok(result);
    }

    private static async Task<IResult> SearchProductsHandler(IProductService productService, string searchText)
    {
        var result = await productService.SearchProductsAsync(searchText);
        return Results.Ok(result);
    }
}