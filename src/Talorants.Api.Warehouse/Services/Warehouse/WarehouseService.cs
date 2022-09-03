using Microsoft.EntityFrameworkCore;
using Talorants.Data.Entities;
using Talorants.Shared.Model;
using Tolerants.Api.Warehouse.Repositories;

namespace Tolerants.Api.Warehouse.Services.Warehouse;

public class WarehouseService : IWarehouseService
{
    private readonly ILogger<WarehouseService> _logger;
    private readonly IWarehouseRepository _warehouse;

    public WarehouseService(IWarehouseRepository warehouse, ILogger<WarehouseService> logger)
    {
        _logger = logger;
        _warehouse = warehouse;
    }

    public async ValueTask<BaseResponse<Models.Warehouse.Warehouse>> CreateAsync(string name, string? adress, ICollection<User>? user, List<Product>? products)
    {
        if(string.IsNullOrWhiteSpace(name))
            return new("Name is invalid");

        if(string.IsNullOrWhiteSpace(adress))
            return new("Adress is invalid");

        var warehouseEntity = new Talorants.Data.Entities.Warehouse(name, adress, user, products);

        try
        {
            var createWarehouse = await _warehouse.AddAsync(warehouseEntity);
            return new(true) { Data = ToModel(createWarehouse) };
        }
        catch(DbUpdateException dbUpdateException)
        {
            _logger.LogInformation("Error occured:", dbUpdateException);
            return new("Warehouse name already exists.");
        }
        catch (Exception e)
        {
            _logger.LogError($"Error occured at {nameof(WarehouseService)}", e);
            return new(false);
        }
    }

    public async ValueTask<bool> ExistsAsync(Guid id)
    {
        var warehouseResult = await GetByIdAsync(id);

        return warehouseResult.IsSuccess;
    }

    public async ValueTask<BaseResponse<List<Models.Warehouse.Warehouse>>> GetAll()
    {
        try
        {
            var existingWarehouse = _warehouse.GetAll();
            if(existingWarehouse is null)
                return new("Warehouses are not fond");
            
            var returnWarehouses = existingWarehouse
                .Select(e => ToModel(e))
                .ToListAsync();
            
            return new(true) { Data = await returnWarehouses };
        }
        catch (Exception e)
        {
            _logger.LogError($"Error occured at {nameof(WarehouseService)}", e);
            throw new("Couldn't get warehouses. Contact support.", e);
        }        
    }

    public async ValueTask<BaseResponse<Models.Warehouse.Warehouse>> GetByIdAsync(Guid id)
    {
        try
        {
            var existingWarehouse =  await _warehouse.GetAll().FirstOrDefaultAsync(w => w.Id == id);
            if(existingWarehouse is null)
                return new($"Warehouse with given {id} not found");
            
            return new(true) { Data = ToModel(existingWarehouse) };
        }
        catch (Exception e)
        {
            _logger.LogError($"Error occured {nameof(WarehouseService)}", e);   
            throw new("Couldn't get warehouse. Contact support.", e);
        }
    }

    public async ValueTask<BaseResponse<Models.Warehouse.Warehouse>> RemoveById(Guid id)
    {
        try
        {
            var existingWarehouse = _warehouse.GetById(id);
            if(existingWarehouse is null)
                return new($"Warehouse with given {id} not found");

            var removedWarehouse = await _warehouse.Remove(existingWarehouse);
            if(removedWarehouse is null)
                return new("Removing the warehouse failed. Contact support.");

            return new(true) { Data = ToModel(removedWarehouse) };
        }
        catch (Exception e)
        {
            _logger.LogError($"Error occured at {nameof(WarehouseService)}", e);
            throw new("Couldn't remove warehouse. Contact support.", e);
        }
    }

    public async ValueTask<BaseResponse<Models.Warehouse.Warehouse>> UpdateAsync(Guid id, string name, string? adress, ICollection<User>? user, List<Product>? products)
    {
        var existingWarehouse = _warehouse.GetById(id);
        if(existingWarehouse is null)
            return new($"Warehouse with given {id} not found");
        
        existingWarehouse.Name = name;
        existingWarehouse.Adress = adress;
        existingWarehouse.Users = user;
        existingWarehouse.Products = products;

        try
        {
            var updatedWarehouse = await _warehouse.Update(existingWarehouse);
            return new(true) { Data = ToModel(updatedWarehouse) };
        }
        catch(DbUpdateException dbUpdateException)
        {
            _logger.LogInformation("Error occured:", dbUpdateException);
            return new("Warehouse name already exists.");
        }
        catch (Exception e)
        {
            _logger.LogError($"Error occured at {nameof(WarehouseService)}", e);
            throw new("Couldn't remove warehouse. Contact support.", e);
        }
    }

    public static Models.Warehouse.Warehouse ToModel(Talorants.Data.Entities.Warehouse entity)
    => new()
    {
        Id = entity.Id,
        CreatedAt = entity.CreatedAt,
        UpdatedAt = entity.UpdatedAt,
        Name = entity.Name,
        Adress = entity.Adress,
        Users = (ICollection<Talorants.Api.User.Model.User>)entity.Users!,
        Products = entity.Products
    };
}