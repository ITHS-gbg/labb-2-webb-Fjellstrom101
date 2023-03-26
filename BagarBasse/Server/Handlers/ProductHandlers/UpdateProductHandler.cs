using BagarBasse.Server.Requests.ProductRequests;
using MediatR;
using BagarBasse.Server.Services.ProductService;

namespace BagarBasse.Server.Handlers.ProductHandlers;

public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, IResult>
{
    private readonly IProductService _productService;

    public UpdateProductHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IResult> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        var result = await _productService.UpdateProductAsync(request.Product);
        return result;
    }
}