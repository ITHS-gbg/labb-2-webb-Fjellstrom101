using BagarBasse.DataAccess;
using BagarBasse.Shared;
using BagarBasse.Shared.DTOs;
using BagarBasse.Shared.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;

namespace BagarBasse.Server.Services.ProductService;

public class ProductService : IProductService
{
    private readonly StoreUnitOfWork _storeUnitOfWork;

    public ProductService(StoreUnitOfWork storeUnitOfWork)
    {
        _storeUnitOfWork = storeUnitOfWork;
    }

    public async Task<IResult> GetProductsAsync()
    {
        var list = await _storeUnitOfWork.ProductRepository.Get()
            .Where(p => p.Visible)
            .Include(p => p.Variants.Where( v => v.Visible))
            .ThenInclude(p => p.ProductType)
            .OrderBy(p => p.CategoryId)
            .ToListAsync();

        if (!list.Any())
            return TypedResults.NoContent();

        return TypedResults.Ok(list);
    }

    public async Task<IResult> GetAdminProductsAsync()
    {
        var list =  await _storeUnitOfWork.ProductRepository.Get()
            .Include(p => p.Variants)
            .ThenInclude(v => v.ProductType)
            .ToListAsync();
        if (!list.Any())
            return TypedResults.NoContent();

        return TypedResults.Ok(list);
    }

    public async Task<IResult> GetProductAsync(int id)
    {
        var product = await _storeUnitOfWork.ProductRepository.Get()
            .Include(p => p.Variants.Where(v => v.Visible))
            .ThenInclude(v => v.ProductType)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
            return TypedResults.UnprocessableEntity("Product not found");

        return TypedResults.Ok(product);
    }

    public async Task<IResult> GetAdminProductAsync(int id)
    {
        var product = await _storeUnitOfWork.ProductRepository.Get()
            .Include(p => p.Variants)
            .ThenInclude(v => v.ProductType)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
            return TypedResults.UnprocessableEntity("Product not found");

        return TypedResults.Ok(product);
    }

    public async Task<IResult> GetProductsByCategoryAsync(string categoryUrl)
    {
        if (!_storeUnitOfWork.ProductRepository.Get()
            .Any(p => p.Category.Url.ToLower().Equals(categoryUrl.ToLower()) && p.Visible))
            return TypedResults.UnprocessableEntity("Category not found");

        var list = await _storeUnitOfWork.ProductRepository.Get()
            .Where(p => p.Category.Url.ToLower().Equals(categoryUrl.ToLower()) && p.Visible)
            .Include(p => p.Variants)
            .ToListAsync();

        if (!list.Any())
            return TypedResults.NoContent();

        return TypedResults.Ok(list);
    }


    public async Task<IResult> SearchProductsAsync(string searchText)
    {
        var list = await _storeUnitOfWork.ProductRepository.Get()
            .Where(p => p.Title
                            .ToLower()
                            .Contains(searchText.ToLower())
                        || p.Id
                            .ToString()
                            .Contains(searchText.ToLower()))
            .Include(p => p.Variants)
            .ToListAsync();

        if (!list.Any())
            return TypedResults.NoContent();

        return TypedResults.Ok(list);
    }

    public async Task<IResult> CreateProductAsync(Product product)
    {
        foreach (var variant in product.Variants)
        {

            variant.ProductType = null;
        }

        await _storeUnitOfWork.ProductRepository.InsertAsync(product);
        await _storeUnitOfWork.SaveChangesAsync();

        return TypedResults.Ok(product);
    }

    public async Task<IResult> UpdateProductAsync(Product product)
    {

        var dbProduct = await _storeUnitOfWork.ProductRepository.Get()
            .Where(p => p.Id == product.Id)
            .Include(p => p.Variants)
            .FirstOrDefaultAsync();

        if (dbProduct == null)
        {
            return TypedResults.UnprocessableEntity("Product not found");
        }

        dbProduct.Title = product.Title;
        dbProduct.Description = product.Description;
        dbProduct.CategoryId = product.CategoryId;
        dbProduct.Image = product.Image;
        dbProduct.Visible = product.Visible;


        dbProduct.Variants = dbProduct.Variants.Where(v => product.Variants.Any(pv => pv.ProductTypeId == v.ProductTypeId)).ToList();


        foreach (var variant in product.Variants)
        {
            var dbVariant = await _storeUnitOfWork.ProductVariantRepository.Get()
                .FirstOrDefaultAsync(v => v.ProductId == variant.ProductId &&
                                           v.ProductTypeId == variant.ProductTypeId);
            if (dbVariant == null)
            {
                variant.ProductType = null;
                await _storeUnitOfWork.ProductVariantRepository.InsertAsync(variant);
            }
            else
            {
                dbVariant.ProductTypeId = variant.ProductTypeId;
                dbVariant.Price = variant.Price;
                dbVariant.OriginalPrice = variant.OriginalPrice;
                dbVariant.Visible = variant.Visible;
            }
        }



        await _storeUnitOfWork.SaveChangesAsync();

        return TypedResults.Ok(product);

    }

    public async Task<IResult> DeleteProductAsync(int id)
    {
        var dbProduct = await _storeUnitOfWork.ProductRepository.GetByID(id);
        if (dbProduct == null)
        {
            return TypedResults.UnprocessableEntity("Product not found");
        }


        _storeUnitOfWork.ProductRepository.Delete(dbProduct);

        await _storeUnitOfWork.SaveChangesAsync();

        return TypedResults.Ok("Product Removed");
    }

    public async Task<IResult> SetProductVisibility(int id, bool visible)
    {
        var product = await _storeUnitOfWork.ProductRepository.GetByID(id);

        if (product == null)
            return TypedResults.UnprocessableEntity("Product not found");
        
        product.Visible = visible;

        await _storeUnitOfWork.SaveChangesAsync();

        return TypedResults.Ok(product);
    }
}