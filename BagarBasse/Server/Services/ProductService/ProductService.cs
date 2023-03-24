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

    public async Task<List<Product>> GetProductsAsync()
    {
        return await _storeUnitOfWork.ProductRepository.Get()
            .Where(p => p.Visible)
            .Include(p => p.Variants.Where( v => v.Visible))
            .ThenInclude(p => p.ProductType)
            .OrderBy(p => p.CategoryId)
            .ToListAsync();
    }

    public async Task<List<Product>> GetAdminProductsAsync()
    {
        return await _storeUnitOfWork.ProductRepository.Get()
            .Include(p => p.Variants)
            .ThenInclude(v => v.ProductType)
            .ToListAsync();
    }

    public async Task<Product> GetProductAsync(int id)
    {
        var product = await _storeUnitOfWork.ProductRepository.Get()
            .Include(p => p.Variants.Where(v => v.Visible))
            .ThenInclude(v => v.ProductType)
            .FirstOrDefaultAsync(p => p.Id == id);


        return product;
    }
    public async Task<Product> GetAdminProductAsync(int id)
    {
        var product = await _storeUnitOfWork.ProductRepository.Get()
            .Include(p => p.Variants)
            .ThenInclude(v => v.ProductType)
            .FirstOrDefaultAsync(p => p.Id == id);


        return product;
    }


    public async Task<List<Product>> GetProductsByCategoryAsync(string categoryUrl)
    {
        return await _storeUnitOfWork.ProductRepository.Get()
            .Where(p => p.Category.Url.ToLower().Equals(categoryUrl.ToLower()) && p.Visible)
            .Include(p => p.Variants)
            .ToListAsync();
    }


    public async Task<List<Product>> SearchProductsAsync(string searchText)
    {
        return await _storeUnitOfWork.ProductRepository.Get()
            .Where(p => p.Title
                            .ToLower()
                            .Contains(searchText.ToLower())
                        || p.Id
                            .ToString()
                            .Contains(searchText.ToLower()))
            .Include(p => p.Variants)
            .ToListAsync();

    }

    public async Task<Product> CreateProductAsync(Product product)
    {
        //TODO FIX THIS
        foreach (var variant in product.Variants)
        {

            variant.ProductType = null;
        }

        await _storeUnitOfWork.ProductRepository.InsertAsync(product);
        await _storeUnitOfWork.SaveChangesAsync();

        return product;
    }

    public async Task<Product> UpdateProductAsync(Product product)
    {

        var dbProduct = await _storeUnitOfWork.ProductRepository.Get()
            .Where(p => p.Id == product.Id)
            .Include(p => p.Variants)
            .FirstOrDefaultAsync();

        if (dbProduct == null)
        {
            return null;
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

        return product;

    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var dbProduct = await _storeUnitOfWork.ProductRepository.GetByID(id);
        if (dbProduct == null)
        {
            return false;
        }


        _storeUnitOfWork.ProductRepository.Delete(dbProduct);

        await _storeUnitOfWork.SaveChangesAsync();

        return true;
    }
}