using Talorants.Data;
using Talorants.Data.Entities;

namespace Talorants.Warehouse.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async ValueTask<Product> AddAsync(Product entity)
    {
        var entry = await _context.Set<Product>().AddAsync(entity);

        await _context.SaveChangesAsync();

        return entry.Entity;
    }

    public IQueryable<Product> GetAll()
        => _context.Set<Product>();

    public Product? GetById(Guid id)
        => _context.Set<Product>().Find(id);

    public async ValueTask<Product> Remove(Product entity)
    {
        var entry = _context.Set<Product>().Remove(entity);

        await _context.SaveChangesAsync();

        return entry.Entity;
    }

    public async ValueTask<Product> Update(Product entity)
    {
        var entry = _context.Set<Product>().Update(entity);

        await _context.SaveChangesAsync();

        return entry.Entity;
    }
}