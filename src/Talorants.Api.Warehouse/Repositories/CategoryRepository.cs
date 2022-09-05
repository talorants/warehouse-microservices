using Talorants.Data;
using Talorants.Data.Entities;

namespace Talorants.Warehouse.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async ValueTask<Category> AddAsync(Category entity)
    {
        var entry = await _context.Set<Category>().AddAsync(entity);

        await _context.SaveChangesAsync();

        return entry.Entity;
    }

    public IQueryable<Category> GetAll()
        => _context.Set<Category>();

    public Category? GetById(Guid id)
        => _context.Set<Category>().Find(id);

    public async ValueTask<Category> Remove(Category entity)
    {
        var entry = _context.Set<Category>().Remove(entity);

        await _context.SaveChangesAsync();

        return entry.Entity;
    }

    public async ValueTask<Category> Update(Category entity)
    {
        var entry = _context.Set<Category>().Update(entity);

        await _context.SaveChangesAsync();

        return entry.Entity;
    }
}