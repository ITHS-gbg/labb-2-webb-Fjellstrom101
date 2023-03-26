using BagarBasse.Shared.Models;

namespace BagarBasse.Server.Requests.ProductTypeRequests;

public class UpdateProductTypeRequest : IHttpRequest
{
    public ProductType ProductType { get; set; }
}