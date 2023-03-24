using BagarBasse.Shared.Models;
using BagarBasse.Shared;

namespace BagarBasse.Client.Services.ProductService;

public interface IProductService
{
    List<Product> Products { get; set; }

    List<Product> AdminProducts { get; set; }

    Task<List<Product>> GetProductsAsync();

    Task<List<Product>> GetAdminProductsAsync();
    Task<List<Product>> GetProductsByCategoryAsync(string categoryUrl = null);
    Task<Product> GetProductAsync(int id);
    Task<Product> GetAdminProductAsync(int id);

    Task<List<Product>> SearchProductsAsync(string searchText);

    Task<Product> CreateProductAsync(Product product);
    Task<Product> UpdateProductAsync(Product product);
    Task DeleteProductAsync(Product product);

}