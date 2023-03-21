using BagarBasse.Shared.Models;
using BagarBasse.Shared;

namespace BagarBasse.Server.Services.CategoryService;

public interface ICategoryService
{
    Task<List<Category>> GetCategoriesAsync();
    Task<Category> GetCategoryByUrlAsync(string categoryUrl);

    Task<List<Category>> GetAdminCategoriesAsync();
    Task<List<Category>> AddCategoryAsync(Category category);
    Task<List<Category>> UpdateCategoryAsync(Category category);
    Task<List<Category>> DeleteCategoryAsync(int id);
}