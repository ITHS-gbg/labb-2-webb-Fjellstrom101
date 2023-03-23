using BagarBasse.Server.Requests.ProductTypeRequests;
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

    public static WebApplication MapProductTypeApi(this WebApplication app)
    {

        app.MediateGet<GetProductTypesRequest>("/api/producttype");

        app.MediatePost<AddProductTypeRequest>("/api/producttype");

        app.MediatePut<UpdateProductTypeRequest>("/api/producttype");

        return app;
    }

}