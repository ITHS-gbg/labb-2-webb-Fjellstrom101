using BagarBasse.Server.Requests.OrderRequests;
using BagarBasse.Server.Services.OrderService;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace BagarBasse.Server.Handlers.OrderHandlers;

public class GetOrdersHandler : IRequestHandler<GetOrdersRequest,IResult>
{
    private readonly IOrderService _orderService;

    public GetOrdersHandler(IOrderService orderService)
    {
        _orderService = orderService;
    }
    public async Task<IResult> Handle(GetOrdersRequest request, CancellationToken cancellationToken)
    {
        var result = await _orderService.GetOrdersAsync();
        return TypedResults.Ok(result);
    }
}