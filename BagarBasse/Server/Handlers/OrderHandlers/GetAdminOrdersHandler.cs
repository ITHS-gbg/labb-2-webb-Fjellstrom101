﻿using BagarBasse.Server.Requests.OrderRequests;
using BagarBasse.Server.Services.OrderService;
using MediatR;

namespace BagarBasse.Server.Handlers.OrderHandlers;

public class GetAdminOrdersHandler : IRequestHandler<GetAdminOrdersRequest, IResult>
{
    private readonly IOrderService _orderService;

    public GetAdminOrdersHandler(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public async Task<IResult> Handle(GetAdminOrdersRequest request, CancellationToken cancellationToken)
    {
        var result = await _orderService.GetAdminOrdersAsync();
        return result;
    }
}