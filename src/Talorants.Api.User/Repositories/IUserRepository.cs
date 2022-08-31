namespace Talorants.Api.User.Repositories;

public interface IUserRepository<TEntity> where TEntity : Talorants.Data.Entities.User
{
    TEntity? GetById(Guid id);
    IQueryable<TEntity?>? GetAll();
    ValueTask<TEntity?> AddAsync(TEntity entity);
    ValueTask<TEntity?> Remove(TEntity entity);
    ValueTask<TEntity?> Update(TEntity entity);
}