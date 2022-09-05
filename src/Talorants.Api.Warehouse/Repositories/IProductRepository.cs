using Talorants.Data.Entities;

namespace Talorants.Warehouse.Repositories;

public interface IProductRepository{
    Product? GetById(Guid id);
    IQueryable<Product> GetAll();
    ValueTask<Product> AddAsync(Product entity);
    ValueTask<Product> Remove(Product entity);
    ValueTask<Product> Update(Product entity);
}