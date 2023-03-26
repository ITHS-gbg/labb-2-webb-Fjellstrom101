using BagarBasse.Shared.Models;

namespace BagarBasse.Client.Services.ProductService;

public interface IProductService
{
    List<Product> Products { get; set; }

    List<Product> AdminProducts { get; set; }

    Task<List<Product>> GetProductsAsync();

    Task<List<Product>> GetAdminProductsAsync();
    Task<HttpResponseMessage> GetProductsByCategoryAsync(string categoryUrl = null);
    Task<HttpResponseMessage> GetProductAsync(int id);
    Task<Product> GetAdminProductAsync(int id);

    Task<HttpResponseMessage> SearchProductsAsync(string searchText);

    Task<Product> CreateProductAsync(Product product);
    Task<Product> UpdateProductAsync(Product product);
    Task DeleteProductAsync(Product product);

}