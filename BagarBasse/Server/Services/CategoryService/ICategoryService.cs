using BagarBasse.Shared.Models;
using BagarBasse.Shared;

namespace BagarBasse.Server.Services.CategoryService;

public interface ICategoryService
{
    Task<IResult> GetCategoriesAsync();
    Task<IResult> GetAdminCategoriesAsync();
    Task<IResult> AddCategoryAsync(Category category);
    Task<IResult> UpdateCategoryAsync(Category category);
    Task<IResult> DeleteCategoryAsync(int id);
}