using BagarBasse.DataAccess;
using BagarBasse.Shared;
using BagarBasse.Shared.DTOs;
using BagarBasse.Shared.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;

namespace BagarBasse.Server.Services.ProductService;

public class ProductService : IProductService
{
    private readonly DataContext _context;

    public ProductService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        return await _context.Products
            .Include(p => p.Variants)
            .ThenInclude(p => p.ProductType)
            .OrderBy(p => p.CategoryId)
            .ToListAsync();
    }

    public async Task<List<Product>> GetAdminProductsAsync()
    {
        return await _context.Products
            .Where(p => p.Visible && !p.Deleted)
            .Include(p => p.Variants.Where(v => !v.Deleted))
            .ThenInclude(v => v.ProductType)
            .ToListAsync();
    }

    public async Task<Product> GetProductAsync(int id)
    {
        var product = await _context.Products
            .Include(p => p.Variants)
            .ThenInclude(v => v.ProductType)
            .FirstOrDefaultAsync(p => p.Id == id);


        return product;
    }


    public async Task<List<Product>> GetProductsByCategoryAsync(string categoryUrl)
    {
        return await _context.Products.Where(p => p.Category.Url.ToLower().Equals(categoryUrl.ToLower()))
            .Include(p => p.Variants)
            .ToListAsync();
    }


    public async Task<List<Product>> SearchProductsAsync(string searchText)
    {
        return await _context.Products
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

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return product;
    }

    public async Task<Product> UpdateProductAsync(Product product)
    {
        var dbProduct = await _context.Products.FindAsync(product.Id);

        if (dbProduct == null)
        {
            return null;
        }

        dbProduct.Title = product.Title;
        dbProduct.Description = product.Description;
        dbProduct.CategoryId = product.CategoryId;
        dbProduct.Image = product.Image;
        dbProduct.Visible = product.Visible;

        foreach (var variant in product.Variants)
        {
            var dbVariant = await _context.ProductVariants
                .FirstOrDefaultAsync(v => v.ProductId == variant.ProductId &&
                                           v.ProductTypeId == variant.ProductTypeId);
            if (dbVariant == null)
            {
                variant.ProductType = null;
                _context.ProductVariants.Add(variant);
            }
            else
            {
                dbVariant.ProductTypeId = variant.ProductTypeId;
                dbVariant.Price = variant.Price;
                dbVariant.OriginalPrice = variant.OriginalPrice;
                dbVariant.Visible = variant.Visible;
                dbVariant.Deleted = variant.Deleted;
            }
        }

        await _context.SaveChangesAsync();

        return product;

    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var dbProduct = await _context.Products.FindAsync(id);
        if (dbProduct == null)
        {
            return false;
        }

        dbProduct.Deleted = true;
        await _context.SaveChangesAsync();

        return true;
    }
}