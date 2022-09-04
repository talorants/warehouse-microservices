using Talorants.Data.Entities;
using Talorants.Shared.Model;

namespace Tolerants.Api.Warehouse.Services;

public interface IWarehouseService
{
    ValueTask<BaseResponse<List<Models.Warehouse.Warehouse>>> GetAll();
    ValueTask<BaseResponse<Models.Warehouse.Warehouse>> GetByIdAsync(Guid id);
    ValueTask<BaseResponse<Models.Warehouse.Warehouse>> RemoveById(Guid id);
    ValueTask<BaseResponse<Models.Warehouse.Warehouse>> CreateAsync(string name, string? adress, ICollection<Talorants.Data.Entities.User>? user, List<Models.Product.Product>? products);
    ValueTask<BaseResponse<Models.Warehouse.Warehouse>> UpdateAsync(Guid id, string name, string? adress, ICollection<Talorants.Data.Entities.User>? user, List<Models.Product.Product>? products);
    ValueTask<bool> ExistsAsync(Guid id);
}
