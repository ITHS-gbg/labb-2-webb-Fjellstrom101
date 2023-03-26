using BagarBasse.Server.Requests.ProductTypeRequests;
using BagarBasse.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using System.Data;
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
        return TypedResults.Ok(response);
    }
}