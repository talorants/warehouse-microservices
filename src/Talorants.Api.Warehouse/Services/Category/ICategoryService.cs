using Talorants.Data.Entities;
using Talorants.Shared.Model;

namespace Tolerants.Api.Warehouse.Services.Category;

public interface ICategoryService
{
    ValueTask<BaseResponse<List<Models.Category.Category>>> GetAll();
    ValueTask<BaseResponse<Models.Category.Category>> CreateAsync(string? name, ICollection<Models.Product.Product>? products);
}