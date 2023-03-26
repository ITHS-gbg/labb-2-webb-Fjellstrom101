using BagarBasse.Shared.DTOs;
using BagarBasse.Shared.DTOs.OrderDTOs;

namespace BagarBasse.Client.Services.OrderService;

public interface IOrderService
{
    Task PlaceOrder();
    Task<List<OrderOverviewDto>> GetOrders();
    Task<List<OrderOverviewDto>> GetAdminOrders();
    Task<OrderDto> GetOrderDetails(string id);
}