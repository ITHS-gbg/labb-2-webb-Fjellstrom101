using BagarBasse.Shared.Models;
using BagarBasse.Shared;
using BagarBasse.Shared.DTOs;

namespace BagarBasse.Server.Services.ProductService;

public interface IProductService
{
    Task<ServiceResponse<List<Product>>> GetProductsAsync();
    Task<ServiceResponse<Product>> GetProductAsync(int id);
    Task<ServiceResponse<List<Product>>> GetProductsByCategoryAsync(string categoryUrl);
    Task<ServiceResponse<List<Product>>> SearchProducts(string searchText);
}