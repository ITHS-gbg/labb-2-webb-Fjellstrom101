using BagarBasse.DataAccess;
using BagarBasse.Shared;
using BagarBasse.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BagarBasse.Server.Services.CategoryService;

public class CategoryService : ICategoryService
{
    private readonly StoreUnitOfWork _storeUnitOfWork;

    public CategoryService(StoreUnitOfWork storeUnitOfWork)
    {
        _storeUnitOfWork = storeUnitOfWork;
    }

    public async Task<List<Category>> GetCategoriesAsync()
    {
        var categories = await _storeUnitOfWork.CategoryRepository.Get()
                                            .Where(c => c.Visible && !c.Deleted).ToListAsync();
        return categories;
    }

    public async Task<List<Category>> GetAdminCategoriesAsync()
    {
        var categories = await _storeUnitOfWork.CategoryRepository.Get().Where(c => c.Visible).ToListAsync();
        return categories;
    }

    public async Task<List<Category>> AddCategoryAsync(Category category)
    {
        category.Editing = category.IsNew = false;
        await _storeUnitOfWork.CategoryRepository.InsertAsync(category);
        await _storeUnitOfWork.SaveChangesAsync();
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

        await _storeUnitOfWork.SaveChangesAsync();
        return await GetAdminCategoriesAsync();
    }

    public async Task<List<Category>> DeleteCategoryAsync(int id)
    {
        var category = await GetCategoryById(id);
        if (category == null)
        {
            return null;
        }

        _storeUnitOfWork.CategoryRepository.Delete(category);
        await _storeUnitOfWork.SaveChangesAsync();
        return await GetAdminCategoriesAsync();
    }

    private async Task<Category?> GetCategoryById(int id)
    {
        return await _storeUnitOfWork.CategoryRepository.GetByID(id);
    }
}