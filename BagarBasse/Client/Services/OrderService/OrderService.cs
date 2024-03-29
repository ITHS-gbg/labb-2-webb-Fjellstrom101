﻿using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using BagarBasse.Client.Services.CartService;
using BagarBasse.Shared.DTOs.OrderDTOs;

namespace BagarBasse.Client.Services.OrderService;

public class OrderService : IOrderService
{
    private readonly HttpClient _http;
    private readonly NavigationManager _navigationManager;
    private readonly ICartService _cartService;

    public OrderService(HttpClient http, NavigationManager navigationManager, ICartService cartService)
    {
        _http = http;
        _navigationManager = navigationManager;
        _cartService = cartService;
    }
    public async Task PlaceOrder()
    {
        var result = await _http.PostAsJsonAsync("api/Order", (await _cartService.GetCartItemsAsync()));
        await _cartService.ClearCart();
    }

    public async Task<HttpResponseMessage> GetOrders()
    {
        var result = await _http.GetAsync("api/order");
        return result;
    }

    public async Task<HttpResponseMessage> GetAdminOrders()
    {
        var result = await _http.GetAsync("api/order/admin");
        return result;
    }

    public async Task<OrderDto> GetOrderDetails(string id)
    {
        var result = await _http.GetFromJsonAsync<OrderDto>($"api/order/{id}");
        return result;
    }

}