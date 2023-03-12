using BagarBasse.Shared.Models;
using BagarBasse.Shared;

namespace BagarBasse.Client.Services.ProductService;

public interface IProductService
{
    List<Product> Products { get; set; }

    Task<ServiceResponse<List<Product>>> GetProductsAsync();
    Task<ServiceResponse<List<Product>>> GetProductsByCategoryAsync(string categoryUrl = null);
    Task<ServiceResponse<Product>> GetProductAsync(int id);

}