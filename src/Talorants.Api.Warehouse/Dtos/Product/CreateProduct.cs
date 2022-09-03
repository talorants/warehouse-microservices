using Talorants.Data.Entities;

namespace Tolerants.Api.Warehouse.Dtos.Product;

public class CreateProduct
{
    public string? Name { get; set; }
    public int Amount { get; set; }
    public double InitialPrice { get; set; }
    public double? SellingPrice { get; set; }
    public Category? Category { get; set; }
    public virtual Talorants.Data.Entities.Warehouse? Warehouse { get; set; }
}