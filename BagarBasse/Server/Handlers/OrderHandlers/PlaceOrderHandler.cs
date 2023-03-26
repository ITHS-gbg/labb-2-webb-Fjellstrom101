using BagarBasse.Server.Requests.OrderRequests;
using BagarBasse.Server.Services.OrderService;
using MediatR;

namespace BagarBasse.Server.Handlers.OrderHandlers;

public class PlaceOrderHandler : IRequestHandler<PlaceOrderRequest, IResult>
{
    private readonly IOrderService _orderService;

    public PlaceOrderHandler(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public async Task<IResult> Handle(PlaceOrderRequest request, CancellationToken cancellationToken)
    {
        var result = await _orderService.PlaceOrderAsync(request.CartItems);
        return result;
    }
}