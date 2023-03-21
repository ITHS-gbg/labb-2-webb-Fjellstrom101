using BagarBasse.Server.Services.ProductTypeService;
using BagarBasse.Shared.Models;
using Microsoft.AspNetCore.Authorization;

namespace BagarBasse.Server.Extensions;

public static class ProductTypeApiExtension
{

    public static IServiceCollection UseProductTypeApi(this IServiceCollection services)
    {
        services.AddScoped<IProductTypeService, ProductTypeService>();
        return services;
    }
    public static WebApplication MapProductTypeApi(this WebApplication webApplication)
    {
        webApplication.MapGet("/api/producttype", GetProductTypesHandler);

        webApplication.MapPost("/api/producttype", AddProductTypeHandler);

        webApplication.MapPut("/api/producttype", UpdateProductTypeHandler);

        return webApplication;
    }


    [Authorize(Roles = "Admin")]
    private static async Task<IResult> GetProductTypesHandler(IProductTypeService productTypeService)
    {
        var response = await productTypeService.GetProductTypesAsync();
        return Results.Ok(response);
    }

    [Authorize(Roles = "Admin")]
    private static async Task<IResult> AddProductTypeHandler(IProductTypeService productTypeService,
        ProductType productType)
    {
        var response = await productTypeService.AddProductTypeAsync(productType);
        return TypedResults.Ok(response);
    }

    [Authorize(Roles = "Admin")]
    private static async Task<IResult> UpdateProductTypeHandler(IProductTypeService productTypeService,
        ProductType productType)
    {
        var response = await productTypeService.UpdateProductTypeAsync(productType);
        return response != null ? TypedResults.Ok(response) : TypedResults.BadRequest("Product Type not found");
    }
}