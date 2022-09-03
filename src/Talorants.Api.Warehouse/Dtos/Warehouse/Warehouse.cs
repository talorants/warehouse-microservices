using Talorants.Api.User.Model;

namespace Tolerants.Api.Warehouse.Dtos.Warehouse;

public class Warehouse
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string? Name { get; set; }
    public string? Adress { get; set; }
    public virtual ICollection<User>? Users { get; set; }
    public virtual ICollection<Talorants.Data.Entities.Product>? Products { get; set; }
}