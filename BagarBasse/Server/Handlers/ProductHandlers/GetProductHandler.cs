using BagarBasse.Server.Requests.ProductRequests;
using BagarBasse.Server.Services.ProductService;
using MediatR;

namespace BagarBasse.Server.Handlers.ProductHandlers;

public class GetProductHandler : IRequestHandler<GetProductRequest, IResult>
{
    private readonly IProductService _productService;

    public GetProductHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IResult> Handle(GetProductRequest request, CancellationToken cancellationToken)
    {
        var result = await _productService.GetProductAsync(request.Id);
        return result;
    }
}