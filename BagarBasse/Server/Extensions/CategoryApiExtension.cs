using BagarBasse.Server.Requests.CategoryRequest;
using BagarBasse.Server.Services.CategoryService;
using BagarBasse.Shared.Models;
using Microsoft.AspNetCore.Authorization;

namespace BagarBasse.Server.Extensions;

public static class CategoryApiExtension
{
    public static WebApplication MapCategoryApi(this WebApplication app)
    {
        app.MediateGet<GetCategoriesRequest>("/api/category");

        app.MediateGet<GetAdminCategoriesRequest>("/api/category/admin");

        app.MediatePost<AddCategoryRequest>("/api/category/admin");

        app.MediatePut<UpdateCategoryRequest>("/api/category/admin");

        app.MediateDelete<DeleteCategoryRequest>("/api/category/admin/{id:int}");

        return app;
    }
}