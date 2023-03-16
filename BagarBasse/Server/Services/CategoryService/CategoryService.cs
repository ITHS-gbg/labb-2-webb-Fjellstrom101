using BagarBasse.DataAccess;
using BagarBasse.Shared;
using BagarBasse.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BagarBasse.Server.Services.CategoryService;

public class CategoryService : ICategoryService
{
    private readonly DataContext _dataContext;

    public CategoryService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ServiceResponse<List<Category>>> GetCategoriesAsync()
    {
        var categories = await _dataContext.Categories.ToListAsync();
        return new ServiceResponse<List<Category>>()
        {
            Data = categories
        };
    }

    public async Task<ServiceResponse<Category>> GetCategoryByUrl(string categoryUrl)
    {
        var categories = await _dataContext.Categories.FirstOrDefaultAsync(c => c.Url.Equals(categoryUrl));

        if (categories == null)
        {
            return new ServiceResponse<Category>()
            {
                Success = false,
                Message = "Category not found"
            };
        }

        return new ServiceResponse<Category>()
        {
            Data = categories
        };
    }

}