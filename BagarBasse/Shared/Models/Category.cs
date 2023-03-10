using System.ComponentModel.DataAnnotations.Schema;

namespace BagarBasse.Shared.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string BackgroundCssClass { get; set; } = string.Empty;

    public bool Visible { get; set; } = true;
    public bool Deleted { get; set; } = false;

    public List<Product> Products { get; set; }
}