using BagarBasse.Server.Requests.ProductRequests;
using BagarBasse.Server.Services.ProductService;
using MediatR;

namespace BagarBasse.Server.Handlers.ProductHandlers;

public class GetProductsHandler : IRequestHandler<GetProductsRequest, IResult>
{
    private readonly IProductService _productService;

    public GetProductsHandler(IProductService productService)
    {
        _productService = productService;
    }
    public async Task<IResult> Handle(GetProductsRequest request, CancellationToken cancellationToken)
    {
        var result = await _productService.GetProductsAsync();
        return TypedResults.Ok(result);
    }
}