using BagarBasse.Server.Requests.ProductRequests;
using BagarBasse.Server.Services.ProductService;
using MediatR;

namespace BagarBasse.Server.Handlers.ProductHandlers;

public class GetProductsByCategoryHandler : IRequestHandler<GetProductsByCategoryRequest, IResult>
{
    private readonly IProductService _productService;

    public GetProductsByCategoryHandler(IProductService productService)
    {
        _productService = productService;
    }
    public async Task<IResult> Handle(GetProductsByCategoryRequest request, CancellationToken cancellationToken)
    {
        var result = await _productService.GetProductsByCategoryAsync(request.CategoryUrl);
        return result;
    }
}