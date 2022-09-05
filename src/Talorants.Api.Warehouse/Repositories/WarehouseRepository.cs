using Talorants.Data;

namespace Talorants.Warehouse.Repositories;

public class WarehouseRepository : IWarehouseRepository
{
    private readonly AppDbContext _context;

    public WarehouseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async ValueTask<Data.Entities.Warehouse> AddAsync(Data.Entities.Warehouse entity)
    {
        var entry = await _context.Set<Data.Entities.Warehouse>().AddAsync(entity);

        await _context.SaveChangesAsync();

        return entry.Entity;
    }

    public IQueryable<Data.Entities.Warehouse> GetAll()
        => _context.Set<Data.Entities.Warehouse>();

    public Data.Entities.Warehouse? GetById(Guid id)
        => _context.Set<Data.Entities.Warehouse>().Find(id);

    public async ValueTask<Data.Entities.Warehouse> Remove(Data.Entities.Warehouse entity)
    {
        var entry = _context.Set<Data.Entities.Warehouse>().Remove(entity);

        await _context.SaveChangesAsync();

        return entry.Entity;
    }

    public async ValueTask<Data.Entities.Warehouse> Update(Data.Entities.Warehouse entity)
    {
        var entry = _context.Set<Data.Entities.Warehouse>().Update(entity);

        await _context.SaveChangesAsync();

        return entry.Entity;
    }
}