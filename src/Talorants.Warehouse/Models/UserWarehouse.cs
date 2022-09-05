using Talorants.Api.User.Model;

namespace Talorants.Warehouse.Models;

public class UserWarehouse
{
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public Guid WarehouseId { get; set; }
    public Warehouse? Warehouse { get; set; }
}