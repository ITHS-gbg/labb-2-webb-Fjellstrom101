using BagarBasse.Shared.Models;

namespace BagarBasse.Server.Requests.CategoryRequest;

public class UpdateCategoryRequest : IHttpRequest
{
    public Category Category { get; set; }
}