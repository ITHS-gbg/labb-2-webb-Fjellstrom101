using BagarBasse.Server.Requests.ProductRequests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using BagarBasse.Server.Services.ProductService;
using BagarBasse.Shared.Models;

namespace BagarBasse.Server.Handlers.ProductHandlers;

[Authorize(Roles = "Admin")]
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
        return result != null ? TypedResults.Ok(result) : TypedResults.NotFound("Product not found");
    }
}