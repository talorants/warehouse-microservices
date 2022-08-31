using Talorants.Data;

namespace Talorants.Api.User.Repository;

public class UserRepository : IUserRepository<Data.Entities.User>
{
    private readonly AppDbContext _dbContext;
    private readonly ILogger<UserRepository> _logger;

    public UserRepository(AppDbContext context, ILogger<UserRepository> logger)
    {
        _dbContext = context;
        _logger = logger;
    }

    public async ValueTask<Data.Entities.User> AddAsync(Data.Entities.User? entity)
    {
        var entry = await _dbContext.Users!.AddAsync(entity!);

        await _dbContext.SaveChangesAsync();

        return entry.Entity;
    }

    public IQueryable<Data.Entities.User> GetAll()
        => _dbContext.Users!;    /// we should discussion here '!'

    public Data.Entities.User? GetById(ulong id)
        => _dbContext?.Users?.Find(id);

    public async ValueTask<Data.Entities.User> Remove(Data.Entities.User entity)
    {
        var entry = _dbContext.Users?.Remove(entity);

        await _dbContext.SaveChangesAsync();

        return entry!.Entity;
    }

    public async ValueTask<Data.Entities.User> Update(Data.Entities.User entity)
    {
        var entry = _dbContext.Users?.Update(entity);

        await _dbContext.SaveChangesAsync();

        return entry!.Entity;
    }
}