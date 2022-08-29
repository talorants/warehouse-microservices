namespace Talorants.Data.Entities;

public class Product : EntityBase
{
    public string? Name { get; set; }
    public int Amount { get; set; }
    public double InitialPrice { get; set; }
    public double? SellingPrice { get; set; }
    public Warehouse? Warehouse { get; set; }
    public Category? Category { get; set; }
}