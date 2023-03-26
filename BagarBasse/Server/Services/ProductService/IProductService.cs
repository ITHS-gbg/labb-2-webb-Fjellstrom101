using BagarBasse.Shared.Models;
using BagarBasse.Shared;
using BagarBasse.Shared.DTOs;

namespace BagarBasse.Server.Services.ProductService;

public interface IProductService
{
    Task<IResult> GetProductsAsync();
    Task<IResult> GetAdminProductsAsync();
    Task<IResult> GetProductAsync(int id);
    Task<IResult> GetAdminProductAsync(int id);
    Task<IResult> GetProductsByCategoryAsync(string categoryUrl);
    Task<IResult> SearchProductsAsync(string searchText);
    Task<IResult> CreateProductAsync(Product product);
    Task<IResult> UpdateProductAsync(Product product);
    Task<IResult> DeleteProductAsync(int id);
    Task<IResult> SetProductVisibility(int id, bool visible);

}