using System.Linq.Expressions;
using Talorants.Api.User.Repositories;
using Talorants.Shared.Model;

namespace Talorants.Api.User.Services;

public class UserService : IUserService
{
    private readonly IUserRepository<Data.Entities.User> _userRepository;
    private readonly ILogger<UserService> _logger;

    public UserService(IUserRepository<Data.Entities.User> userRepository, ILogger<UserService> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }

    public async ValueTask<BaseResponse<Data.Entities.User>> CreateAsync(Model.User model)
    {
        if (string.IsNullOrWhiteSpace(model.Name))
            return new("Name is invalid");

        if (string.IsNullOrWhiteSpace(model.Login))
            return new("Login is invalid");

        if (string.IsNullOrWhiteSpace(model.Password))
            return new("Password is invalid");

        throw new NotImplementedException();

    }


    public ValueTask<BaseResponse<Data.Entities.User>> FindAsync(Expression<Func<Model.User, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public ValueTask<BaseResponse<IQueryable<Data.Entities.User>>> GetAllUsersAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<BaseResponse<Data.Entities.User>> RemoveByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<BaseResponse<Data.Entities.User>> RemoveRangeAsync(IEnumerable<Model.User> models)
    {
        throw new NotImplementedException();
    }

    public ValueTask<BaseResponse<Data.Entities.User>> UpdateAsync(Model.User model)
    {
        throw new NotImplementedException();
    }
}