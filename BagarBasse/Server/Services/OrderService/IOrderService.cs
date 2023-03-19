using BagarBasse.Shared;
using BagarBasse.Shared.DTOs;
using BagarBasse.Shared.Models;

namespace BagarBasse.Server.Services.OrderService;

public interface IOrderService
{
    Task<ServiceResponse<bool>> PlaceOrder(List<CartItem> products);
    Task<ServiceResponse<List<OrderOverviewDto>>> GetOrders();
    Task<ServiceResponse<OrderDetailsDto>> GetOrderDetails(int orderId);
}