namespace BagarBasse.Server.Requests.ProductRequests;

public class SearchProductsRequest : IHttpRequest
{
    public string SearchText { get; set; }
}