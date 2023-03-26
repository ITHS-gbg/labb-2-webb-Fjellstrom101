using BagarBasse.Server.Requests.ProductRequests;
using BagarBasse.Server.Services.ProductService;
using MediatR;

namespace BagarBasse.Server.Handlers.ProductHandlers;

public class SetProductVisibilityHandler :  IRequestHandler<SetProductVisibilityRequest, IResult>
{
    private readonly IProductService _productService;

    public SetProductVisibilityHandler(IProductService productService)
    {
        _productService = productService;
    }
    public async Task<IResult> Handle(SetProductVisibilityRequest request, CancellationToken cancellationToken)
    {
        var result = await _productService.SetProductVisibility(request.Id, request.Visible);
        return result;
    }
}