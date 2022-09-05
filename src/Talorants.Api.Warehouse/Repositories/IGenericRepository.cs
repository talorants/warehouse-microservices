namespace Talorants.Warehouse.Repositories;

public interface IGenericRepository<TEntity> where TEntity : class
{
    TEntity? GetById(Guid id);
    IQueryable<TEntity> GetAll();
    ValueTask<TEntity> AddAsync(TEntity entity);
    ValueTask<TEntity> Remove(TEntity entity);
    ValueTask<TEntity> Update(TEntity entity);
}