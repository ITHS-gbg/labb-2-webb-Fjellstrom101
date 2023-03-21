using System.Net.Http.Json;
using BagarBasse.Shared;
using BagarBasse.Shared.Models;
using static System.Net.WebRequestMethods;

namespace BagarBasse.Client.Services.CategoryService;

public class CategoryService  : ICategoryService
{
    private readonly HttpClient _publicHttpClient;
    private readonly HttpClient _httpClient;

    public event Action? OnChange;
    public List<Category> Categories { get; set; } = new List<Category>();
    public List<Category> AdminCategories { get; set; } = new List<Category>();

    public CategoryService(IHttpClientFactory itHttpClientFactory)
    {
        _publicHttpClient = itHttpClientFactory.CreateClient("BagarBasse.PublicServerAPI");
        _httpClient = itHttpClientFactory.CreateClient("BagarBasse.ServerAPI");
    }

    public async Task GetCategories()
    {
        var response = await _publicHttpClient.GetFromJsonAsync<List<Category>>("api/category");
        if (response != null)
        {
            Categories = response;
        }
    }

    public async Task GetCategoryByUrl(string categoryUrl)
    {
        var response = await _publicHttpClient.GetFromJsonAsync<Category>($"api/single-category/{categoryUrl}");
        if (response != null)
        {
            Categories = new List<Category> { response };
        }
    }

    public async Task GetAdminCategories()
    {
        var response = await _httpClient.GetFromJsonAsync<List<Category>>("api/category/admin");
        if (response != null)
        {
            AdminCategories = response;
        }
    }

    public async Task AddCategory(Category category)
    {
        var response = await _httpClient.PostAsJsonAsync("api/category/admin", category);
        AdminCategories = await response.Content.ReadFromJsonAsync<List<Category>>();

        await GetCategories();
        OnChange.Invoke();
    }

    public async Task DeleteCategory(int categoryId)
    {
        var response = await _httpClient.DeleteAsync($"api/category/admin/{categoryId}");
        AdminCategories = await response.Content.ReadFromJsonAsync<List<Category>>();

        await GetCategories();
        OnChange.Invoke();
    }

    public async Task UpdateCategory(Category category)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/category/admin", category);
        AdminCategories = await response.Content.ReadFromJsonAsync<List<Category>>();

        await GetCategories();
        OnChange.Invoke();
    }

    public Category CreateNewCategory()
    {
        var category = new Category
        {
            IsNew = true,
            Editing = true
        };
        AdminCategories.Add(category);
        OnChange.Invoke();

        return category;
    }
}