namespace Talorants.Shared.Models;

public class Warehouse
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string? Name { get; set; }
    public string? Adress { get; set; }
    public ICollection<UserWarehouse>? UserWarehouses { get; set; }
    public ICollection<Product>? Products { get; set; }
}