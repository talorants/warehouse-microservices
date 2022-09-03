using Talorants.Data;
using Talorants.Data.Entities;

namespace Tolerants.Api.Warehouse.Repositories;

public class WarehouseRepository : GenericRepository<Talorants.Data.Entities.Warehouse>
{
    public WarehouseRepository(AppDbContext context) 
        : base(context) { }
}