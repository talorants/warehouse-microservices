using Talorants.Data;

namespace Talorants.Warehouse.Repositories;

public class WarehouseRepository : GenericRepository<Data.Entities.Warehouse>
{
    public WarehouseRepository(AppDbContext context) : base(context) { }
}