﻿using BagarBasse.Shared;
using BagarBasse.Shared.DTOs;
using BagarBasse.Shared.DTOs.OrderDTOs;
using BagarBasse.Shared.Models;

namespace BagarBasse.Server.Services.OrderService;

public interface IOrderService
{
    Task<bool> PlaceOrderAsync(List<CartItem> products);
    Task<List<OrderOverviewDto>> GetOrdersAsync();
    Task<OrderDto> GetOrderDetailsAsync(string orderId);
    Task<List<OrderOverviewDto>> GetAdminOrdersAsync();
}