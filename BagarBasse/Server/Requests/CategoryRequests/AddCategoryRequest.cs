using BagarBasse.Shared.Models;

namespace BagarBasse.Server.Requests.CategoryRequest;

public class AddCategoryRequest : IHttpRequest
{
    public Category Category { get; set; }
}