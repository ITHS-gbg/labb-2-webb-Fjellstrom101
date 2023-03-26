namespace BagarBasse.Server.Requests.ProductRequests;

public class GetProductsByCategoryRequest : IHttpRequest
{
    public string CategoryUrl { get; set; }
}