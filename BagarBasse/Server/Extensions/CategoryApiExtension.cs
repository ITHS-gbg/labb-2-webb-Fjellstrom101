using BagarBasse.Server.Services.CategoryService;
using BagarBasse.Shared.Models;
using Microsoft.AspNetCore.Authorization;

namespace BagarBasse.Server.Extensions;

public static class CategoryApiExtension
{
    public static WebApplication MapCategoryApi(this WebApplication webApplication)
    {
        webApplication.MapGet("/api/category", GetCategoriesHandler);

        webApplication.MapGet("/api/single-category/{categoryUrl}", GetCategoryByUrlHandler);

        webApplication.MapGet("/api/category/admin", GetAdminCategoriesHandler);

        webApplication.MapPost("/api/category/admin", AddCategoryHandler);

        webApplication.MapPut("/api/category/admin", UpdateCategoryHandler);

        webApplication.MapDelete("/api/category/admin/{id:int}", DeleteCategoryHandler);

        return webApplication;
    }

    private static async Task<IResult> GetCategoriesHandler(ICategoryService categoryService)
    {
        var result = await categoryService.GetCategoriesAsync();
        return TypedResults.Ok(result);
    }

    private static async Task<IResult> GetCategoryByUrlHandler(ICategoryService categoryService, string categoryUrl)
    {
        var result = await categoryService.GetCategoryByUrlAsync(categoryUrl);
        return result != null ? TypedResults.Ok(result) : TypedResults.NotFound("Category not found");
    }

    [Authorize(Roles = "Admin")]
    private static async Task<IResult> GetAdminCategoriesHandler(ICategoryService categoryService)
    {
        var result = await categoryService.GetAdminCategoriesAsync();
        return TypedResults.Ok(result);
    }

    [Authorize(Roles = "Admin")]
    private static async Task<IResult> AddCategoryHandler(ICategoryService categoryService, Category category)
    {
        var result = await categoryService.AddCategoryAsync(category);
        return TypedResults.Ok(result);
    }

    [Authorize(Roles = "Admin")]
    private static async Task<IResult> UpdateCategoryHandler(ICategoryService categoryService, Category category)
    {
        var result = await categoryService.UpdateCategoryAsync(category);
        return result != null ? TypedResults.Ok(result) : TypedResults.NotFound("Category not found");
    }

    [Authorize(Roles = "Admin")]
    private static async Task<IResult> DeleteCategoryHandler(ICategoryService categoryService, int id)
    {
        var result = await categoryService.DeleteCategoryAsync(id);
        return result != null ? TypedResults.Ok(result) : TypedResults.NotFound("Category not found");
    }
}