using BagarBasse.Shared.Models;

namespace BagarBasse.Client.Services.CategoryService;

public interface ICategoryService
{
    event Action ProductsChanged;
    List<Category> Categories { get; set; }
    Task GetCategories();
    Task GetCategoryByUrl(string categoryUrl);
}