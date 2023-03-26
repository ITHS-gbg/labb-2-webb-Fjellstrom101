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

    public async Task<IResult> GetCategoriesAsync()
    {
        var categories = await _storeUnitOfWork.CategoryRepository.Get()
                                            .Where(c => c.Visible).ToListAsync();
        if (!categories.Any())
            return TypedResults.NoContent();

        return TypedResults.Ok(categories);
    }

    public async Task<IResult> GetAdminCategoriesAsync()
    {
        var categories = await _storeUnitOfWork.CategoryRepository.Get().ToListAsync();
        if (!categories.Any())
            return TypedResults.NoContent();

        return TypedResults.Ok(categories);
    }

    public async Task<IResult> AddCategoryAsync(Category category)
    {
        category.Editing = category.IsNew = false;
        await _storeUnitOfWork.CategoryRepository.InsertAsync(category);
        await _storeUnitOfWork.SaveChangesAsync();

        return await GetAdminCategoriesAsync();
    }

    public async Task<IResult> UpdateCategoryAsync(Category category)
    {
        var categoryToUpdate = await GetCategoryByIdAsync(category.Id);

        if (categoryToUpdate == null)
        {
            return TypedResults.UnprocessableEntity("Category not found");
        }

        categoryToUpdate.Name = category.Name;
        categoryToUpdate.Url = category.Url;
        categoryToUpdate.Visible = category.Visible;

        await _storeUnitOfWork.SaveChangesAsync();
        return await GetAdminCategoriesAsync();
    }

    public async Task<IResult> DeleteCategoryAsync(int id)
    {
        var category = await GetCategoryByIdAsync(id);
        if (category == null)
        {
            return TypedResults.UnprocessableEntity("Category not found");
        }

        _storeUnitOfWork.CategoryRepository.Delete(category);
        await _storeUnitOfWork.SaveChangesAsync();

        return await GetAdminCategoriesAsync();
    }

    private async Task<Category?> GetCategoryByIdAsync(int id)
    {
        return await _storeUnitOfWork.CategoryRepository.GetByID(id);
    }
}