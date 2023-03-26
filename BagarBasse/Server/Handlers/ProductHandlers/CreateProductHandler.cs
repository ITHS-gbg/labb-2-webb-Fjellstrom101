using Microsoft.AspNetCore.Authorization;
using System.Data;
using BagarBasse.Server.Requests.ProductRequests;
using BagarBasse.Server.Services.ProductService;
using MediatR;
using BagarBasse.Shared.Models;

namespace BagarBasse.Server.Handlers.ProductHandlers;

public class CreateProductHandler : IRequestHandler<CreateProductRequest, IResult>
{
    private readonly IProductService _productService;

    public CreateProductHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IResult> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var result = await _productService.CreateProductAsync(request.Product);
        return TypedResults.Ok(result);
    }
}