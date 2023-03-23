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

    public async Task<List<Category>> GetCategoriesAsync()
    {
        var categories = await _dataContext.Categories.Where(c => c.Visible && !c.Deleted).ToListAsync();
        return categories;
    }

    public async Task<List<Category>> GetAdminCategoriesAsync()
    {
        var categories = await _dataContext.Categories.Where(c => c.Visible).ToListAsync();
        return categories;
    }

    public async Task<List<Category>> AddCategoryAsync(Category category)
    {
        category.Editing = category.IsNew = false;
        _dataContext.Categories.Add(category);
        await _dataContext.SaveChangesAsync();
        return await GetAdminCategoriesAsync();
    }

    public async Task<List<Category>> UpdateCategoryAsync(Category category)
    {
        var categoryToUpdate = await GetCategoryById(category.Id);
        if (categoryToUpdate == null)
        {
            return null;
        }

        categoryToUpdate.Name = category.Name;
        categoryToUpdate.Url = category.Url;
        categoryToUpdate.Visible = category.Visible;

        await _dataContext.SaveChangesAsync();
        return await GetAdminCategoriesAsync();
    }

    public async Task<List<Category>> DeleteCategoryAsync(int id)
    {
        var category = await GetCategoryById(id);
        if (category == null)
        {
            return null;
        }

        _dataContext.Categories.Remove(category);
        await _dataContext.SaveChangesAsync();
        return await GetAdminCategoriesAsync();
    }

    private async Task<Category?> GetCategoryById(int id)
    {
        return await _dataContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
    }
}