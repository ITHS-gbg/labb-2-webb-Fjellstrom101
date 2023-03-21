using BagarBasse.DataAccess;
using BagarBasse.Shared.Models;
using BagarBasse.Shared;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BagarBasse.Server.Services.ProductTypeService;

public class ProductTypeService : IProductTypeService
{
    private readonly DataContext _dataContext;

    public ProductTypeService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public async Task<List<ProductType>> GetProductTypesAsync()
    {
        var productTypes = await _dataContext.ProductTypes.ToListAsync();
        return productTypes;
    }

    public async Task<List<ProductType>> AddProductTypeAsync(ProductType productType)
    {
        productType.IsNew = productType.Editing = false;
        await _dataContext.ProductTypes.AddAsync(productType);
        await _dataContext.SaveChangesAsync();

        return await GetProductTypesAsync();
    }

    public async Task<List<ProductType>?> UpdateProductTypeAsync(ProductType productType)
    {
        var dbProductType = await _dataContext.ProductTypes.FindAsync(productType.Id);

        if (dbProductType == null)
        {
            return null;
        }

        dbProductType.Name = productType.Name;
        await _dataContext.SaveChangesAsync();

        return await GetProductTypesAsync();
    }
}