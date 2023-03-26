using BagarBasse.Server.Requests.ProductTypeRequests;
using BagarBasse.Server.Services.ProductTypeService;

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

        app.MediateAuthorizedGet<GetProductTypesRequest>("/api/producttype", "Admin");

        app.MediateAuthorizedPost<AddProductTypeRequest>("/api/producttype", "Admin");

        app.MediateAuthorizedPut<UpdateProductTypeRequest>("/api/producttype", "Admin");

        return app;
    }

}