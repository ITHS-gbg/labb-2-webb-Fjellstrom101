using BagarBasse.Shared.DTOs.OrderDTOs;

namespace BagarBasse.Client.Services.OrderService;

public interface IOrderService
{
    Task PlaceOrder();
    Task<HttpResponseMessage> GetOrders();
    Task<HttpResponseMessage> GetAdminOrders();
    Task<OrderDto> GetOrderDetails(string id);
}