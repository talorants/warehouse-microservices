using Talorants.Data;
using Talorants.Data.Entities;

namespace Talorants.Warehouse.Repositories;

public class ProductRepository : GenericRepository<Product>
{
    public ProductRepository(AppDbContext context) : base(context) { }
}