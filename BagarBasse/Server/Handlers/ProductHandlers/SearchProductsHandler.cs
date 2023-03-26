
using BagarBasse.Server.Requests.ProductRequests;
using BagarBasse.Server.Services.ProductService;
using MediatR;

namespace BagarBasse.Server.Handlers.ProductHandlers;

public class SearchProductsHandler : IRequestHandler<SearchProductsRequest, IResult>
{
    private readonly IProductService _productService;

    public SearchProductsHandler(IProductService productService)
    {
        _productService = productService;
    }
    public async Task<IResult> Handle(SearchProductsRequest request, CancellationToken cancellationToken)
    {
        var result = await _productService.SearchProductsAsync(request.SearchText);
        return result;
    }
}