using BagarBasse.Shared.Models;
using BagarBasse.Shared;
using System.Net.Http.Json;

namespace BagarBasse.Client.Services.ProductService;

public class ProductService : IProductService
{
    private readonly HttpClient _http;

    public ProductService(HttpClient http)
    {
        _http = http;
    }

    public event Action? ProductsChanged;
    public List<Product> Products { get; set; } = new List<Product>();
    public async Task GetProductAsync(string categoryUrl = null)
    {
        var result = categoryUrl == null ?
            await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product") :
            await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/Category/{categoryUrl}");

        if (result != null && result.Data != null)
            Products = result.Data;

        ProductsChanged.Invoke();
    }

    public async Task<ServiceResponse<Product>> GetProductAsync(int id)
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{id}");
        return result;

    }
}