using BagarBasse.Shared.Models;
using BagarBasse.Shared;

namespace BagarBasse.Client.Services.ProductService;

public interface IProductService
{
    event Action ProductsChanged;
    List<Product> Products { get; set; }

    Task GetProductAsync(string categoryUrl = null);
    Task<ServiceResponse<Product>> GetProductAsync(int id);

}