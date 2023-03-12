using System.Net.Http.Json;
using BagarBasse.Shared;
using BagarBasse.Shared.Models;
using static System.Net.WebRequestMethods;

namespace BagarBasse.Client.Services.CategoryService;

public class CategoryService  : ICategoryService
{
    private readonly HttpClient _httpClient;

    public event Action? ProductsChanged;
    public List<Category> Categories { get; set; } = new List<Category>();

    public CategoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task GetCategories()
    {
        var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/category");
        if (response != null && response.Data != null)
        {
            Categories = response.Data;
        }
    }

    public async Task GetCategoryByUrl(string categoryUrl)
    {
        var response = await _httpClient.GetFromJsonAsync<ServiceResponse<Category>>($"api/single-category/{categoryUrl}");
        if (response != null && response.Data != null)
        {
            Categories = new List<Category> { response.Data };
        }
    }
}