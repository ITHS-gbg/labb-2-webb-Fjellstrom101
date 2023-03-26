using BagarBasse.Shared.Models;
using BagarBasse.Shared;
using System.Net.Http.Json;
using BagarBasse.Shared.DTOs;
using System.Net.Http;

namespace BagarBasse.Client.Services.ProductService;

public class ProductService : IProductService
{
    private readonly HttpClient _http;

    public ProductService(HttpClient http)
    {
        _http = http;
    }

    public List<Product> Products { get; set; } = new List<Product>();
    public List<Product> AdminProducts { get; set; } = new List<Product>();

    public async Task<List<Product>> GetProductsAsync()
    {
        var result = await _http.GetFromJsonAsync<List<Product>>("api/product");
        return result;
    }

    public async Task<List<Product>> GetAdminProductsAsync()
    {
        var result = await _http.GetFromJsonAsync<List<Product>>("api/product/admin");
        return result;
    }

    public async Task<List<Product>> GetProductsByCategoryAsync(string categoryUrl = null)
    {
        var result = await _http.GetFromJsonAsync<List<Product>>($"api/category/{categoryUrl}");
        return result;
    }

    public async Task<HttpResponseMessage> GetProductAsync(int id)
    {
        var result = await _http.GetAsync($"api/product/{id}");
        //var result = await _http.GetFromJsonAsync<Product>($"api/product/{id}");
        return result;
    }

    public async Task<Product> GetAdminProductAsync(int id)
    {
        var result = await _http.GetFromJsonAsync<Product>($"api/product/admin/{id}");
        return result;
    }

    public async Task<List<Product>> SearchProductsAsync(string searchText)
    {
        var result = await _http.GetFromJsonAsync<List<Product>>($"api/search/{searchText}");
        return result;

    }

    public async Task<Product> CreateProductAsync(Product product)
    {
        var result = await _http.PostAsJsonAsync("api/product", product);
        var newProduct = await result.Content.ReadFromJsonAsync<Product>();
        return newProduct;
    }

    public async Task<Product> UpdateProductAsync(Product product)
    {
        var result = await _http.PutAsJsonAsync("api/product", product);
        return await result.Content.ReadFromJsonAsync<Product>();
    }

    public async Task DeleteProductAsync(Product product)
    {
        var result = await _http.DeleteAsync($"api/product/{product.Id}");
    }
}