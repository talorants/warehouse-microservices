using Talorants.Data;

namespace Talorants.Api.User.Repositories;

public class UserRepository : IUserRepository<Data.Entities.User>
{
    private readonly AppDbContext _dbContext;
    private readonly ILogger<UserRepository> _logger;

    public UserRepository(AppDbContext context, ILogger<UserRepository> logger)
    {
        _dbContext = context;
        _logger = logger;
    }

    public async ValueTask<Data.Entities.User?> AddAsync(Data.Entities.User entity)
    {
        var entry = await _dbContext.Set<Data.Entities.User>().AddAsync(entity);

        await _dbContext.SaveChangesAsync();

        return entry.Entity;
    }

    public IQueryable<Data.Entities.User> GetAll()
        => _dbContext.Set<Data.Entities.User>();

    public Data.Entities.User? GetById(Guid id)
        => _dbContext?.Set<Data.Entities.User>().Find(id);

    public async ValueTask<Data.Entities.User?> Remove(Data.Entities.User entity)
    {
        var entry = _dbContext.Set<Data.Entities.User>().Remove(entity);

        await _dbContext.SaveChangesAsync();

        return entry?.Entity;
    }

    public async ValueTask RemoveRange(IEnumerable<Data.Entities.User> entities)
    {
        _dbContext.Set<Data.Entities.User>().RemoveRange(entities);

        await _dbContext.SaveChangesAsync();
    }

    public async ValueTask<Data.Entities.User?> Update(Data.Entities.User entity)
    {
        var entry = _dbContext.Set<Data.Entities.User>().Update(entity);

        await _dbContext.SaveChangesAsync();

        return entry?.Entity;
    }
}