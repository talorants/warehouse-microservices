using Microsoft.EntityFrameworkCore;
using Talorants.Shared.Model;
using Tolerants.Api.Warehouse.Models.Product;
using Tolerants.Api.Warehouse.Repositories;
using Tolerants.Api.Warehouse.Services.Category;

namespace Talorants.Api.Warehouse.Services.Category;

public class CategoryService : ICategoryService
{
    private readonly ILogger<CategoryService> _logger;
    private readonly ICategoryRepository _category;

    public CategoryService(ILogger<CategoryService> logger,
        ICategoryRepository category)
    {
        _logger = logger;
        _category = category;
    }

    public async ValueTask<BaseResponse<Tolerants.Api.Warehouse.Models.Category.Category>> CreateAsync(string? name, ICollection<Product>? products)
    {
        if(string.IsNullOrWhiteSpace(name))
            return new("Name is invalid");
        
        var categoryEntities = new Data.Entities.Category(name, products?.Select(ToEntity).ToList());

        try
        {
            var createCategory = await _category.AddAsync(categoryEntities);
            return new(true) { Data = ToModel(createCategory) };
        }
        catch(DbUpdateException dbUpdateException)
        {
            _logger.LogInformation("Error occured:", dbUpdateException);
            return new("Categories name already exists.");
        }
        catch (Exception e)
        {
            _logger.LogError($"Error occured at {nameof(CategoryService)}", e);
            return new(false);
        }
    }

    public async ValueTask<BaseResponse<List<Tolerants.Api.Warehouse.Models.Category.Category>>> GetAll()
    {
        try
        {
            var categoryResult = _category.GetAll();
            if(categoryResult is null)
                return new("Category id not found");

            var returnCategory = categoryResult
                .Select(e => ToModel(e))
                .ToListAsync();

            return new(true) { Data = await returnCategory };
        }
        catch (Exception e)
        {
            _logger.LogError($"Error occured at {nameof(CategoryService)}", e);
            throw new("Couldn't get category. Contact support.", e);
        }
    }

    public static Data.Entities.Product ToEntity(Product model)
    => new()
    {
        Id = model.Id,
        CreatedAt = model.CreatedAt,
        UpdatedAt = model.UpdatedAt,
        Name = model.Name,
        Amount = model.Amount,
        InitialPrice = model.InitialPrice,
        SellingPrice = model.SellingPrice,
        Category = model.Category,
        Warehouse = model.Warehouse
    };

    public static Tolerants.Api.Warehouse.Models.Category.Category ToModel(Data.Entities.Category entity)
    => new()
    {
        Name = entity.Name,
        Products = entity.Products
    };
}