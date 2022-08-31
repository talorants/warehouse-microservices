using System.Linq.Expressions;
using Talorants.Shared.Model;

namespace Talorants.Api.User.Services;

public interface IUserService
{
    ValueTask<BaseResponse<IQueryable<Data.Entities.User>>> GetAllUsersAsync();
    ValueTask<BaseResponse<Data.Entities.User>> FindAsync(Expression<Func<Model.User, bool>> expression);
    ValueTask<BaseResponse<Data.Entities.User>> RemoveByIdAsync(Guid id);
    ValueTask<BaseResponse<Data.Entities.User>> RemoveRangeAsync(IEnumerable<Model.User> models);
    ValueTask<BaseResponse<Data.Entities.User>> CreateAsync(Model.User model);
    ValueTask<BaseResponse<Data.Entities.User>> UpdateAsync(Model.User model);
}