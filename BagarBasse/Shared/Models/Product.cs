namespace BagarBasse.Shared.Models;

public class Product
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Ingredients { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public Category? Category { get; set; }
    public int CategoryId { get; set; }
    public List<ProductVariant> Variants { get; set; } = new List<ProductVariant>();
    public bool Deleted { get; set; } = false;
    public bool IsNew { get; set; }
}