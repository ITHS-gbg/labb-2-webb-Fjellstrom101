using BagarBasse.Shared.Models;
using BagarBasse.Shared;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BagarBasse.Server.Services.ProductTypeService;

public interface IProductTypeService
{

    Task<IResult> GetProductTypesAsync();
    Task<IResult> AddProductTypeAsync(ProductType productType);
    Task<IResult> UpdateProductTypeAsync(ProductType productType);
}