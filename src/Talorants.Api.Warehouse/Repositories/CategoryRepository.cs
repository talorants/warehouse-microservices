using Talorants.Data;
using Talorants.Data.Entities;

namespace Tolerants.Api.Warehouse.Repositories;

public class CategoryRepository : GenericRepository<Category>
{
    public CategoryRepository(AppDbContext context) 
        : base(context) { }
}