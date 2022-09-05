namespace Talorants.Shared.Models;

public class Category 
{
    public string? Name { get; set; }
    public ICollection<ProductCategory>? ProductCategories { get; set; }
}