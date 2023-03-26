using BagarBasse.Server.Requests.ProductRequests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using BagarBasse.Server.Services.ProductService;

namespace BagarBasse.Server.Handlers.ProductHandlers;

public class GetAdminProductsHandler : IRequestHandler<GetAdminProductsRequest, IResult>
{
    private readonly IProductService _productService;

    public GetAdminProductsHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IResult> Handle(GetAdminProductsRequest request, CancellationToken cancellationToken)
    {
        var result = await _productService.GetAdminProductsAsync();
        return result;
    }
}