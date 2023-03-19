using BagarBasse.Shared.DTOs;
using BagarBasse.Shared;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using BagarBasse.Client.Services.CartService;

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
        _cartService.ClearCart();
    }

    public async Task<List<OrderOverviewDto>> GetOrders()
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<List<OrderOverviewDto>>>("api/order");
        return result.Data;
    }

    public async Task<OrderDetailsDto> GetOrderDetails(int orderId)
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<OrderDetailsDto>>($"api/order/{orderId}");
        return result.Data;
    }

}