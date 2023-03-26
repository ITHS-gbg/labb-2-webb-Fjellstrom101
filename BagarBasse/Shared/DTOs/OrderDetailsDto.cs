using BagarBasse.Shared.DTOs.OrderDTOs;

namespace BagarBasse.Shared.DTOs;

public class OrderDetailsDto
{
    public DateTime OrderDate { get; set; }
    public decimal TotalPrice { get; set; }
    public List<OrderItemDto> Products { get; set; }
}