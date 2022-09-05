namespace Talorants.Warehouse.Repositories;

public interface IWarehouseRepository{
    Data.Entities.Warehouse? GetById(Guid id);
    IQueryable<Data.Entities.Warehouse> GetAll();
    ValueTask<Data.Entities.Warehouse> AddAsync(Data.Entities.Warehouse entity);
    ValueTask<Data.Entities.Warehouse> Remove(Data.Entities.Warehouse entity);
    ValueTask<Data.Entities.Warehouse> Update(Data.Entities.Warehouse entity);
}