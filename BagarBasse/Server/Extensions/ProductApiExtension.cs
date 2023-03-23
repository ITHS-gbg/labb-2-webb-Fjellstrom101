using BagarBasse.Server.Services.ProductService;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using BagarBasse.Server.Handlers.ProductHandlers;
using BagarBasse.Server.Requests.ProductRequests;
using BagarBasse.Shared.Models;

namespace BagarBasse.Server.Extensions;

public static class ProductApiExtension
{
    public static WebApplication MapProductApi(this WebApplication app)
    {
        app.MediateGet<GetProductsRequest>("/api/product");

        app.MediateGet<GetAdminProductsRequest>("/api/product/admin");

        app.MediatePost<CreateProductRequest>("/api/product/");

        app.MediatePut<UpdateProductRequest>("/api/product/");

        app.MediateDelete<DeleteProductRequest>("/api/product/{id:int}");

        app.MediateGet<GetProductRequest>("/api/product/{id:int}");

        app.MediateGet<GetProductsByCategoryRequest>("/api/category/{categoryUrl}");

        app.MediateGet<SearchProductsRequest>("/api/search/{searchText}");

        return app;
    }
}