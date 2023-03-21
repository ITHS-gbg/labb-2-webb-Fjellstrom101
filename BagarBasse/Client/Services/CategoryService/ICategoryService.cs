using BagarBasse.Shared.Models;

namespace BagarBasse.Client.Services.CategoryService;

public interface ICategoryService
{
    event Action OnChange;
    List<Category> Categories { get; set; }
    List<Category> AdminCategories { get; set; }
    Task GetCategories();
    Task GetCategoryByUrl(string categoryUrl);

    Task GetAdminCategories();
    Task AddCategory(Category category);
    Task DeleteCategory(int categoryId);
    Task UpdateCategory(Category category);
    Category CreateNewCategory();
}