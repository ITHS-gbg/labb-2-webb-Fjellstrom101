using BagarBasse.Server.Requests.ProductRequests;
using MediatR;
using BagarBasse.Server.Services.ProductService;

namespace BagarBasse.Server.Handlers.ProductHandlers;

public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, IResult>
{
    private readonly IProductService _productService;

    public DeleteProductHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IResult> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
    {
        var result = await _productService.DeleteProductAsync(request.Id);
        return result;
    }
}