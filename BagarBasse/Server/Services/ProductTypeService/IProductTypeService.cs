using BagarBasse.Shared.Models;
using BagarBasse.Shared;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BagarBasse.Server.Services.ProductTypeService;

public interface IProductTypeService
{

    Task<List<ProductType>> GetProductTypesAsync();
    Task<List<ProductType>> AddProductTypeAsync(ProductType productType);
    Task<List<ProductType>?> UpdateProductTypeAsync(ProductType productType);
}