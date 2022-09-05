namespace Talorants.Shared.Models;

public class Product
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string? Name { get; set; }
    public int Amount { get; set; }
    public double InitialPrice { get; set; }
    public double? SellingPrice { get; set; }
    public ICollection<ProductCategory>? ProductCategories { get; set; }
    public Warehouse? Warehouse { get; set; }}