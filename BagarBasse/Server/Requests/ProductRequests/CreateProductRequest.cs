using BagarBasse.Shared.Models;

namespace BagarBasse.Server.Requests.ProductRequests;

public class CreateProductRequest : IHttpRequest
{
    public Product Product { get; set; }
}