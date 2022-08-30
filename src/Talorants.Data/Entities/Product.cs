namespace Talorants.Data.Entities;

public class Product : EntityBase
{
    public string? Name { get; set; }
    public int Amount { get; set; }
    public double InitialPrice { get; set; }
    public double? SellingPrice { get; set; }
    public Category? Category { get; set; }
    public virtual Warehouse? Warehouse { get; set; }
}