using Talorants.Shared.Model;

namespace Tolerants.Api.Warehouse.Services.Product;

public interface IProductService
{
    ValueTask<BaseResponse<List<Models.Product.Product>>> GetAll();
    ValueTask<BaseResponse<Models.Product.Product>> GetByIdAsync(Guid id);
    ValueTask<BaseResponse<Models.Product.Product>> RemoveBuId(Guid id);
    ValueTask<BaseResponse<Models.Product.Product>> CreateAsync(string? name, int amount, double initialPrice, double sellingPrice, Models.Category.Category category, Talorants.Data.Entities.Warehouse warehouse);
    ValueTask<BaseResponse<Models.Product.Product>> UpdateAsync(Guid id, string? name, int amount, double initialPrice, double sellingPrice, Models.Category.Category category, Talorants.Data.Entities.Warehouse warehouse);
    ValueTask<bool> ExistsAsync(Guid id);
}