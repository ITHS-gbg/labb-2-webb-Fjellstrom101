using BagarBasse.DataAccess;
using BagarBasse.Shared.Models;
using BagarBasse.Shared;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BagarBasse.Server.Services.ProductTypeService;

public class ProductTypeService : IProductTypeService
{
    private readonly StoreUnitOfWork _storeUnitOfWork;

    public ProductTypeService(StoreUnitOfWork storeUnitOfWork)
    {
        _storeUnitOfWork = storeUnitOfWork;
    }
    public async Task<IResult> GetProductTypesAsync()
    {
        var productTypes = await _storeUnitOfWork.ProductTypeRepository.Get().ToListAsync();
        return TypedResults.Ok(productTypes);
    }

    public async Task<IResult> AddProductTypeAsync(ProductType productType)
    {
        productType.IsNew = productType.Editing = false;
        await _storeUnitOfWork.ProductTypeRepository.InsertAsync(productType);
        await _storeUnitOfWork.SaveChangesAsync();

        return TypedResults.Ok(await GetProductTypesAsync());
    }

    public async Task<IResult> UpdateProductTypeAsync(ProductType productType)
    {
        var dbProductType = await _storeUnitOfWork.ProductTypeRepository.GetByID(productType.Id);

        if (dbProductType == null)
        {
            return TypedResults.UnprocessableEntity("Product Type not found");
        }

        dbProductType.Name = productType.Name;

        await _storeUnitOfWork.SaveChangesAsync();

        return TypedResults.Ok(await GetProductTypesAsync());
    }
}