using BagarBasse.Shared.Models;
using BagarBasse.Shared;
using System.Net.Http.Json;
using BagarBasse.Shared.DTOs;

namespace BagarBasse.Client.Services.ProductService;

public class ProductService : IProductService
{
    private readonly HttpClient _http;

    public ProductService(HttpClient http)
    {
        _http = http;
    }

    public List<Product> Products { get; set; } = new List<Product>();
    public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product");
        return result;
    }


    public async Task<ServiceResponse<List<Product>>> GetProductsByCategoryAsync(string categoryUrl = null)
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/category/{categoryUrl}");
        return result;
    }

    public async Task<ServiceResponse<Product>> GetProductAsync(int id)
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{id}");
        return result;

    }

    public async Task<ServiceResponse<List<Product>>> SearchProducts(string searchText)
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/search/{searchText}");
        return result;

    }
}