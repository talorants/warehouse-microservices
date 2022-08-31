using Talorants.Shared.Model;

namespace Talorants.Api.User.Services;

public interface IUserService
{
    ValueTask<BaseResponse<Data.Entities.User>> GetAllPaginatedUsersAsync(int page, int limit);
    ValueTask<BaseResponse<Data.Entities.User>> GetByIdAsync(Guid id);
    ValueTask<BaseResponse<Data.Entities.User>> FindByNameAsync(string name);
    ValueTask<BaseResponse<Data.Entities.User>> RemoveByIdAsync(Guid id);
    ValueTask<BaseResponse<Data.Entities.User>> CreateAsync(Model.User model);
    ValueTask<BaseResponse<Data.Entities.User>> UpdateAsync(Model.User model);
    ValueTask<bool> ExistsAsync(Guid id);
}