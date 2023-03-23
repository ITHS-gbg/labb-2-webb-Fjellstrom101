namespace BagarBasse.Server.Requests.ProductRequests;

public class GetProductRequest : IHttpRequest
{
    public int Id { get; set; }
}