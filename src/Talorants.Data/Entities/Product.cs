namespace Talorants.Data.Entities;

public class Product : EntityBase
{
    // [Obsolete]
    public Product() { }
    
    public Product(string? name, int amount, double initialPrice, double? sellingPrice, Category? category, Warehouse? warehouse)
    {
        Name = name;
        Amount = amount;
        InitialPrice = initialPrice;
        SellingPrice = sellingPrice;
        Category = category;
        Warehouse = warehouse;
    }

    public string? Name { get; set; }
    public int Amount { get; set; }
    public double InitialPrice { get; set; }
    public double? SellingPrice { get; set; }
    public Category? Category { get; set; }
    public virtual Warehouse? Warehouse { get; set; }
}