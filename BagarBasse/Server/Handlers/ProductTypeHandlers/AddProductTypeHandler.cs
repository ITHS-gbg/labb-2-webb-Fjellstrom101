using BagarBasse.Server.Requests.ProductTypeRequests;
using MediatR;
using BagarBasse.Server.Services.ProductTypeService;

namespace BagarBasse.Server.Handlers.ProductTypeHandlers;

public class AddProductTypeHandler : IRequestHandler<AddProductTypeRequest, IResult>
{
    private readonly IProductTypeService _productTypeService;

    public AddProductTypeHandler(IProductTypeService productTypeService)
    {
        _productTypeService = productTypeService;
    }

    public async Task<IResult> Handle(AddProductTypeRequest request, CancellationToken cancellationToken)
    {
        var response = await _productTypeService.AddProductTypeAsync(request.ProductType);
        return response;
    }
}