using BagarBasse.Shared.Models;

namespace BagarBasse.Server.Services.ProductTypeService;

public interface IProductTypeService
{

    Task<IResult> GetProductTypesAsync();
    Task<IResult> AddProductTypeAsync(ProductType productType);
    Task<IResult> UpdateProductTypeAsync(ProductType productType);
}