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

    public ValueTask<BaseResponse<Data.Entities.User>> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> ExistsAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<BaseResponse<Data.Entities.User>> CreateAsync(Model.User model)
    {
        throw new NotImplementedException();
    }


    public ValueTask<BaseResponse<Data.Entities.User>> FindByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public ValueTask<BaseResponse<Data.Entities.User>> GetAllPaginatedUsersAsync(int page, int limit)
    {
        throw new NotImplementedException();
    }


    public ValueTask<BaseResponse<Data.Entities.User>> RemoveByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<BaseResponse<Data.Entities.User>> UpdateAsync(Model.User model)
    {
        throw new NotImplementedException();
    }
}