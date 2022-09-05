using Talorants.Data.Entities;

namespace Talorants.Warehouse.Repositories;

public interface ICategoryRepository {
    Category? GetById(Guid id);
    IQueryable<Category> GetAll();
    ValueTask<Category> AddAsync(Category entity);
    ValueTask<Category> Remove(Category entity);
    ValueTask<Category> Update(Category entity);
}