using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Talorants.Api.User.Repositories;
using Talorants.Data.Entities;  // we should change this namespace to talorants.warehouse
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

    public async ValueTask<BaseResponse<Model.User>> CreateAsync(string? name, string? login, string? password,
                                                                string? phoneNumber, UserGroup? userGroup, Warehouse? warehouse)
    {
        if (string.IsNullOrWhiteSpace(name))
            return new("Name is invalid");

        if (string.IsNullOrWhiteSpace(login))
            return new("Login is invalid");

        if (string.IsNullOrWhiteSpace(password))
            return new("Password is invalid");

        var userEntity = new Data.Entities.User()
        {
            Name = name,
            Login = login,
            Password = password,
            PhoneNumber = phoneNumber,
            UserGroup = userGroup,
            Warehouse = warehouse
        };

        try
        {
            var createdUser = await _userRepository.AddAsync(userEntity);

            return new(true) { Data = ToModel(createdUser!) };
        }
        catch (DbUpdateException dbUpdateException)
        {
            _logger.LogInformation("Error occured:", dbUpdateException);
            return new("User already exists.");
        }
        catch (Exception e)
        {
            _logger.LogError($"Error occured at {nameof(UserService)}", e);
            throw new("Couldn't create user. Contact support.", e);
        }
    }

    public async ValueTask<BaseResponse<IQueryable<Model.User>>> GetAllUsersAsync()
    {
        try
        {
            var existingUsers = await _userRepository?.GetAll()?.ToListAsync()!;
            if (existingUsers is null || existingUsers.Count() == 0)
                return new("No users found");

            var users = existingUsers.Select(e => ToModel(e));

            return new(true) { Data = users.AsQueryable() };
        }
        catch (Exception e)
        {
            _logger.LogInformation($"Error occured at {nameof(UserService)}", e);
            throw new("Couldn't get users. Contact support.", e);
        }
    }

    public async ValueTask<BaseResponse<Model.User>> RemoveByIdAsync(Guid id)
    {
        try
        {
            var existingUsers = _userRepository.GetById(id);
            if (existingUsers is null)
                return new("User with given Id Not found");

            var removedUser = await _userRepository.Remove(existingUsers);
            if (removedUser is null)
                return new("Removing the user failed. Contact support.");

            return new(true) { Data = ToModel(removedUser) };
        }
        catch (Exception e)
        {
            _logger.LogError($"Error occured at {nameof(UserService)}", e);
            throw new("Couldn't remove user. Contact support.", e);
        }
    }



    public async ValueTask<BaseResponse<Model.User>> UpdateAsync(string? name, string? login, string? password,
                                                                string? phoneNumber, UserGroup? userGroup, Warehouse? warehouse)
    {
        if (string.IsNullOrWhiteSpace(name))
            return new("Name is invalid");

        if (string.IsNullOrWhiteSpace(login))
            return new("Login is invalid");

        if (string.IsNullOrWhiteSpace(password))
            return new("Password is invalid");

        var userEntity = new Data.Entities.User()
        {
            Name = name,
            Login = login,
            Password = password,
            PhoneNumber = phoneNumber,
            UserGroup = userGroup,
            Warehouse = warehouse
        };

        try
        {
            var updatedUser = await _userRepository.Update(userEntity);
            return new(true) { Data = ToModel(updatedUser) };
        }
        catch (DbUpdateException dbUpdateException)
        {
            _logger.LogInformation("Error occured:", dbUpdateException);
            return new("User already exists.");
        }
        catch (Exception e)
        {
            _logger.LogError($"Error occured at {nameof(UserService)}", e);
            throw new("Couldn't update user. Contact support.", e);
        }
    }

    public async ValueTask<BaseResponse> RemoveRangeAsync(IEnumerable<Model.User> models)
    {
        if (models.Count() == 0) return new("Models are invalid.");
        try
        {
            await _userRepository.RemoveRange(models.Select(ToEntity));
            return new(true);
        }
        catch (Exception e)
        {
            _logger.LogError($"Error occured at {nameof(UserService)}", e);
            throw new("Couldn't remove user. Contact support.", e);
        }
    }

    public async ValueTask<BaseResponse<IEnumerable<Model.User>>> FindAsync(Expression<Func<Model.User?, bool>> expression)
    {
        if (expression is null)
            return new("expession is invalid");

        try
        {
            var parametres = expression.Parameters[0];
            Expression body = expression.Body;
            var convert = Expression.Convert(body, typeof(bool));
            var result = Expression.Lambda<Func<Data.Entities.User, bool>>(convert, parametres);

            var existingUser = await _userRepository.GetAll()?.Where(result!).ToListAsync()!;

            if (existingUser is null || existingUser.Count() == 0)
                return new("User with given expression not found");

            var users = existingUser.Select(e => ToModel(e));

            return new(true) { Data = users };
        }
        catch (Exception e)
        {
            _logger.LogError($"Error occured at {nameof(UserService)}", e);
            throw new("Couldn't find user. Contact support.", e);
        }
    }

    private Model.User ToModel(Data.Entities.User? entity)
        => new Model.User()
        {
            Id = entity!.Id,
            Name = entity.Name,
            Login = entity.Login,
            Password = entity.Password,
            PhoneNumber = entity.PhoneNumber,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
        };
    private Data.Entities.User ToEntity(Model.User entity)
        => new Data.Entities.User()
        {
            Name = entity.Name,
            Login = entity.Login,
            Password = entity.Password,
            PhoneNumber = entity.PhoneNumber
        };
}