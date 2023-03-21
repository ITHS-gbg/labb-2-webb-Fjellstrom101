using BagarBasse.Shared.Models;
using BagarBasse.Shared;
using BagarBasse.Shared.DTOs;

namespace BagarBasse.Server.Services.ProductService;

public interface IProductService
{
    Task<List<Product>> GetProductsAsync();
    Task<List<Product>> GetAdminProductsAsync();
    Task<Product> GetProductAsync(int id);
    Task<List<Product>> GetProductsByCategoryAsync(string categoryUrl);
    Task<List<Product>> SearchProductsAsync(string searchText);

    Task<Product> CreateProductAsync(Product product);
    Task<Product> UpdateProductAsync(Product product);
    Task<bool> DeleteProductAsync(int id);

}