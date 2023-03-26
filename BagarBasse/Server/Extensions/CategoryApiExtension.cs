using BagarBasse.Server.Requests.CategoryRequest;
using BagarBasse.Server.Services.CategoryService;


namespace BagarBasse.Server.Extensions;

public static class CategoryApiExtension
{
    public static IServiceCollection UseCategoryApi(this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        return services;
    }
    public static WebApplication MapCategoryApi(this WebApplication app)
    {
        app.MediateGet<GetCategoriesRequest>("/api/category");

        app.MediateAuthorizedGet<GetAdminCategoriesRequest>("/api/category/admin", "Admin");

        app.MediateAuthorizedPost<AddCategoryRequest>("/api/category/admin", "Admin");

        app.MediateAuthorizedPut<UpdateCategoryRequest>("/api/category/admin", "Admin");

        app.MediateAuthorizedDelete<DeleteCategoryRequest>("/api/category/admin/{id:int}", "Admin");

        return app;
    }
}