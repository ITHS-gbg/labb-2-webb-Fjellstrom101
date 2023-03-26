using BagarBasse.Server.Requests.OrderRequests;
using BagarBasse.Server.Services.OrderService;
using MediatR;

namespace BagarBasse.Server.Handlers.OrderHandlers;

public class GetOrderDetailsHandler : IRequestHandler<GetOrderDetailsRequest, IResult>
{
    private readonly IOrderService _orderService;

    public GetOrderDetailsHandler(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public async Task<IResult> Handle(GetOrderDetailsRequest request, CancellationToken cancellationToken)
    {
        var result = await _orderService.GetOrderDetailsAsync(request.OrderId);
        return result;
    }
}