using Talorants.Api.User.Model;

namespace Talorants.Warehouse.Models;

public class Warehouse
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string? Name { get; set; }
    public string? Adress { get; set; }
    public UserWarehouse? UserWarehouses { get; set; }
    public Product? Products { get; set; }
}