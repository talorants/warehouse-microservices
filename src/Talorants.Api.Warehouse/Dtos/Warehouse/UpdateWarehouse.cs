using Talorants.Api.User.Model;

namespace Tolerants.Api.Warehouse.Dtos.Warehouse;

public class UpdateWarehouse
{
    public string? Name { get; set; }
    public string? Adress { get; set; }
    public virtual ICollection<User>? Users { get; set; }
    public virtual ICollection<Talorants.Data.Entities.Product>? Products { get; set; }
}