namespace BagarBasse.Server.Requests.OrderRequests;

public class GetOrderDetailsRequest : IHttpRequest
{
    public string OrderId { get; set; }
}