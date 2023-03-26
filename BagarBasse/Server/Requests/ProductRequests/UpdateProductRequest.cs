using BagarBasse.Shared.Models;

namespace BagarBasse.Server.Requests.ProductRequests;

public class UpdateProductRequest : IHttpRequest
{
    public Product Product { get; set; }
}