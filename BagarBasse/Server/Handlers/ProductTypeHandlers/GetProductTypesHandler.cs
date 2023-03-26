using BagarBasse.Server.Requests.ProductTypeRequests;
using BagarBasse.Server.Services.ProductTypeService;
using MediatR;

namespace BagarBasse.Server.Handlers.ProductTypeHandlers;

public class GetProductTypesHandler : IRequestHandler<GetProductTypesRequest, IResult>
{
    private readonly IProductTypeService _productTypeService;

    public GetProductTypesHandler(IProductTypeService productTypeService)
    {
        _productTypeService = productTypeService;
    }

    public async Task<IResult> Handle(GetProductTypesRequest request, CancellationToken cancellationToken)
    {
        var response = await _productTypeService.GetProductTypesAsync();
        return response;
    }
}