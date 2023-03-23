namespace BagarBasse.Server.Requests.OrderRequests;

public class GetOrderDetailsRequest : IHttpRequest
{
    public int OrderId { get; set; }
}