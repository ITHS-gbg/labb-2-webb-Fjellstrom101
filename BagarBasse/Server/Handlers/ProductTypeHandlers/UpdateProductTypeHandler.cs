﻿using BagarBasse.Server.Requests.ProductTypeRequests;
using BagarBasse.Server.Services.ProductTypeService;
using MediatR;

namespace BagarBasse.Server.Handlers.ProductTypeHandlers;

public class UpdateProductTypeHandler : IRequestHandler<UpdateProductTypeRequest, IResult>
{
    private readonly IProductTypeService _productTypeService;

    public UpdateProductTypeHandler(IProductTypeService productTypeService)
    {
        _productTypeService = productTypeService;
    }

    public async Task<IResult> Handle(UpdateProductTypeRequest request, CancellationToken cancellationToken)
    {
        var response = await _productTypeService.UpdateProductTypeAsync(request.ProductType);
        return response;
    }
}