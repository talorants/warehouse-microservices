namespace Talorants.Data.Entities;

public class Warehouse : EntityBase
{
    public string? Name { get; set; }
    public string? Adress { get; set; }
    public ICollection<UserWarehouse>? UserWarehouses { get; set; }
    public ICollection<Product>? Products { get; set; }
}