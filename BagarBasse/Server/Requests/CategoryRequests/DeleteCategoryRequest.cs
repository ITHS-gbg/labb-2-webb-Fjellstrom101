namespace BagarBasse.Server.Requests.CategoryRequest;

public class DeleteCategoryRequest : IHttpRequest
{
    public int Id { get; set; }
}