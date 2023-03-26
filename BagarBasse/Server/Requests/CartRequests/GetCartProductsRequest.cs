using BagarBasse.Shared.Models;

namespace BagarBasse.Server.Requests.CartRequests;

public class GetCartProductsRequest : IHttpRequest
{
    public List<CartItem> CartItems { get; set; }
}