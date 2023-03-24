using BagarBasse.Server.Requests.ProductRequests;
using BagarBasse.Server.Services.ProductService;
using MediatR;

namespace BagarBasse.Server.Handlers.ProductHandlers;

public class GetAdminProductHandler : IRequestHandler<GetAdminProductRequest, IResult>
{
    private readonly IProductService _productService;

    public GetAdminProductHandler(IProductService productService)
    {
        _productService = productService;
    }
    public async Task<IResult> Handle(GetAdminProductRequest request, CancellationToken cancellationToken)
    {
        var response = await _productService.GetAdminProductAsync(request.Id);
        return response != null
            ? TypedResults.Ok(response)
            : TypedResults.NotFound("Sorry, but this product does not exist.");
    }
}