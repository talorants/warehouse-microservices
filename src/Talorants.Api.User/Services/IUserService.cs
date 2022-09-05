using System.Linq.Expressions;
using Talorants.Data.Entities; // we should change this namespace to talorants.warehouse
using Talorants.Shared.Models;

namespace Talorants.Api.User.Services;

public interface IUserService
{
    ValueTask<BaseResponse<IQueryable<Model.User>>> GetAllUsersAsync();
    ValueTask<BaseResponse<IEnumerable<Model.User>>> FindAsync(Expression<Func<Model.User?, bool>> expression);
    ValueTask<BaseResponse<Model.User>> RemoveByIdAsync(Guid id);
    ValueTask<BaseResponse> RemoveRangeAsync(IEnumerable<Model.User> models);
    ValueTask<BaseResponse<Model.User>> CreateAsync(string? name, string? login, string? password,
                                                                string? phoneNumber, UserGroup? userGroup, Warehouse? warehouse);
    ValueTask<BaseResponse<Model.User>> UpdateAsync(string? name, string? login, string? password,
                                                                string? phoneNumber, UserGroup? userGroup, Warehouse? warehouse);
}