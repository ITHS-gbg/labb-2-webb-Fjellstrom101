using BagarBasse.Server.Requests.CartRequests;
using BagarBasse.Server.Services.CartService;
using BagarBasse.Shared.Models;
using MediatR;

namespace BagarBasse.Server.Handlers.CartHandlers;

public class GetCartProductsHandler : IRequestHandler<GetCartProductsRequest, IResult>
{
    private readonly ICartService _cartService;

    public GetCartProductsHandler(ICartService cartService)
    {
        _cartService = cartService;
    }
    public async Task<IResult> Handle(GetCartProductsRequest request, CancellationToken cancellationToken)
    {
        var result = await _cartService.GetCartProductsAsync(request.CartItems);
        return TypedResults.Ok(result);
    }
}