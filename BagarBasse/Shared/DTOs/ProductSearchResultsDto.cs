using BagarBasse.Shared.Models;

namespace BagarBasse.Shared.DTOs;

public class ProductSearchResultsDto
{
    public List<Product> Products { get; set; } = new List<Product>();
    public int Pages { get; set; }

    public int CurrentPage { get; set; }
}