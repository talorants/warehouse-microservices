namespace Talorants.Data.Entities;

public class ProductCategory
{
    public Guid ProductId {get; set;}
    public Product? Product {get; set;}
    public string? CategoryName { get; set; }
    public Category? Category {get; set;}
}