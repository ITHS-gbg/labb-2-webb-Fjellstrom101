using BagarBasse.Shared.DTOs;

namespace BagarBasse.Client.Services.OrderService;

public interface IOrderService
{
    Task PlaceOrder();
    Task<List<OrderOverviewDto>> GetOrders();
    Task<List<OrderOverviewDto>> GetAdminOrders();
    Task<OrderDetailsDto> GetOrderDetails(int orderId);
}