using Talorants.Data;
using Talorants.Data.Entities;

namespace Tolerants.Api.Warehouse.Repositories;

public class ProductRepository : GenericRepository<Product>
{
    public ProductRepository(AppDbContext context) 
        : base(context) { }
}