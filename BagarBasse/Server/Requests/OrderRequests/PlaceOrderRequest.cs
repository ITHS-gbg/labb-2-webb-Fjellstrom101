using BagarBasse.Shared.Models;

namespace BagarBasse.Server.Requests.OrderRequests;

public class PlaceOrderRequest : IHttpRequest
{
    public List<CartItem> CartItems { get; set; }
}