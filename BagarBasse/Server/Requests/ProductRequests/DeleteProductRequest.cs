using BagarBasse.Shared.Models;

namespace BagarBasse.Server.Requests.ProductRequests;

public class DeleteProductRequest : IHttpRequest
{
    public int Id { get; set; }
}