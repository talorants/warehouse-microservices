using Talorants.Data.Entities;

namespace Tolerants.Api.Warehouse.Models.Product;

public class Product
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string? Name { get; set; }
    public int Amount { get; set; }
    public double InitialPrice { get; set; }
    public double? SellingPrice { get; set; }
    public Category? Category { get; set; }
    public virtual Talorants.Data.Entities.Warehouse? Warehouse { get; set; }
}