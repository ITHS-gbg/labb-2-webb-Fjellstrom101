using BagarBasse.Server.Services.CategoryService;

namespace BagarBasse.Server.Extensions;

public static class CategoryApiExtension
{
    public static WebApplication MapCategoryApi(this WebApplication webApplication)
    {
        webApplication.MapGet("/api/category", async (ICategoryService categoryService) =>
        {
            var result = await categoryService.GetCategoriesAsync();
            return Results.Ok(result);
        });

        return webApplication;
    }
}