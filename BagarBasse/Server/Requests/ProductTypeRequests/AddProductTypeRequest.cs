using BagarBasse.Shared.Models;

namespace BagarBasse.Server.Requests.ProductTypeRequests;

public class AddProductTypeRequest : IHttpRequest
{
    public ProductType ProductType { get; set; }
}