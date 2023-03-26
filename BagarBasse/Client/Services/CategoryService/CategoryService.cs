using System.Net.Http.Json;
using BagarBasse.Shared.Models;

namespace BagarBasse.Client.Services.CategoryService;

public class CategoryService  : ICategoryService
{
    private readonly HttpClient _http;

    public event Action? OnChange;
    public List<Category> Categories { get; set; } = new List<Category>();
    public List<Category> AdminCategories { get; set; } = new List<Category>();
    
    public CategoryService(HttpClient http)
    {
        _http = http;
    }

    public async Task GetCategories()
    {
        var response = await _http.GetFromJsonAsync<List<Category>>("api/category");
        if (response != null)
        {
            Categories = response;
        }
    }

    public async Task GetAdminCategories()
    {
        var response = await _http.GetFromJsonAsync<List<Category>>("api/category/admin");
        if (response != null)
        {
            AdminCategories = response;
        }
    }

    public async Task AddCategory(Category category)
    {
        var response = await _http.PostAsJsonAsync("api/category/admin", category);
        AdminCategories = await response.Content.ReadFromJsonAsync<List<Category>>();

        await GetCategories();
        OnChange.Invoke();
    }

    public async Task DeleteCategory(int categoryId)
    {
        var response = await _http.DeleteAsync($"api/category/admin/{categoryId}");
        AdminCategories = await response.Content.ReadFromJsonAsync<List<Category>>();

        await GetCategories();
        OnChange.Invoke();
    }

    public async Task UpdateCategory(Category category)
    {
        var response = await _http.PutAsJsonAsync($"api/category/admin", category);
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