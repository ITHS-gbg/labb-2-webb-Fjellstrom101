﻿using BagarBasse.Shared.Models;

namespace BagarBasse.Server.Services.OrderService;

public interface IOrderService
{
    Task<IResult> PlaceOrderAsync(List<CartItem> products);
    Task<IResult> GetOrdersAsync();
    Task<IResult> GetOrderDetailsAsync(string orderId);
    Task<IResult> GetAdminOrdersAsync();
}