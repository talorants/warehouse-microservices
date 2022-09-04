using Microsoft.EntityFrameworkCore;
using Talorants.Shared.Model;
using Tolerants.Api.Warehouse.Repositories;

namespace Tolerants.Api.Warehouse.Services.Product;

public class ProductService : IProductService
{
    private readonly ILogger<ProductService> _logger;
    private readonly IProductRepository _product;

    public ProductService(ILogger<ProductService> logger,
        IProductRepository product)
    {
        _logger = logger;
        _product = product;
    }

    public async ValueTask<BaseResponse<Models.Product.Product>> CreateAsync(string? name, int amount, double initialPrice, double sellingPrice, Models.Category.Category category, Talorants.Data.Entities.Warehouse warehouse)
    {
        if(string.IsNullOrWhiteSpace(name))
            return new("Name is invalid");

        if(amount < 0)
            return new("Amount is invalid");
        
        var productsEntity = new Talorants.Data.Entities.Product(name, amount, initialPrice, sellingPrice, ToEntity(category), warehouse);

        try
        {
            var createProduct = await _product.AddAsync(productsEntity);
            return new(true) { Data = ToModel(createProduct) };
        }
        catch(DbUpdateException dbUpdateException)
        {
            _logger.LogInformation("Error occured:", dbUpdateException);
            return new("Product name already exists.");
        }
        catch (Exception e)
        {
            _logger.LogError($"Error occured at {nameof(ProductService)}", e);
            return new(false);
        }
    }

    public async ValueTask<bool> ExistsAsync(Guid id)
    {
        var productResult = await GetByIdAsync(id);

        return productResult.IsSuccess;
    }

    public async ValueTask<BaseResponse<List<Models.Product.Product>>> GetAll()
    {
        try
        {
            var existingProduct = _product.GetAll();
            if(existingProduct is null)
                return new("Producrts are not found");

            var returnProduct = existingProduct
                .Select(e => ToModel(e))
                .ToListAsync();

            return new(true) { Data = await returnProduct };
        }
        catch (Exception e)
        {
            _logger.LogError($"Error occured at {nameof(ProductService)}", e);
            throw new("Couldn't get products. Contact support.", e);
        }
    }

    public async ValueTask<BaseResponse<Models.Product.Product>> GetByIdAsync(Guid id)
    {
        try
        {
            var existingProduct = await _product.GetAll().FirstOrDefaultAsync(w => w.Id == id);
            if(existingProduct is null)
                return new("Product with given id not found");
            
            return new(true) { Data = ToModel(existingProduct) };
        }
        catch (Exception e)
        {
            _logger.LogError($"Error occured {nameof(ProductService)}", e);   
            throw new("Couldn't get product. Contact support.", e);
        }
    }

    public async ValueTask<BaseResponse<Models.Product.Product>> RemoveBuId(Guid id)
    {
        try
        {
            var existingProduct = _product.GetById(id);
            if(existingProduct is null)
                return new("Product with given id not found");

            var removeProduct = await _product.Remove(existingProduct);
            if(removeProduct is null)
                return new("Removing the product failed. Contact support.");

            return new(true) { Data = ToModel(removeProduct) };
        }
        catch (Exception e)
        {
            _logger.LogError($"Error occured {nameof(ProductService)}", e);   
            throw new("Couldn't get product. Contact support.", e);
        }
    }

    public async ValueTask<BaseResponse<Models.Product.Product>> UpdateAsync(Guid id, string? name, int amount, double initialPrice, double sellingPrice, Models.Category.Category category, Talorants.Data.Entities.Warehouse warehouse)
    {
        var existingProduct = _product.GetById(id);
        if(existingProduct is null)
            return new("Product with given id not found");

        existingProduct.Name = name;
        existingProduct.Amount = amount;
        existingProduct.InitialPrice = initialPrice;
        existingProduct.SellingPrice = sellingPrice;
        existingProduct.Category = ToEntity(category);
        existingProduct.Warehouse = warehouse;

        try
        {
            var updateProduct = await _product.Update(existingProduct);
            return new(true) { Data = ToModel(updateProduct) };
        }
        catch(DbUpdateException dbUpdateException)
        {
            _logger.LogInformation("Error occured:", dbUpdateException);
            return new("Product name already exists.");
        }
        catch (Exception e)
        {
            _logger.LogError($"Error occured {nameof(ProductService)}", e);   
            throw new("Couldn't get product. Contact support.", e);
        }
    }

    public static Models.Product.Product ToModel(Talorants.Data.Entities.Product entity)
    => new()
    {
        Id = entity.Id,
        CreatedAt = entity.CreatedAt,
        UpdatedAt = entity.UpdatedAt,
        Name = entity.Name,
        Amount = entity.Amount,
        InitialPrice = entity.InitialPrice,
        SellingPrice = entity.SellingPrice,
        Category = entity.Category,
        Warehouse = entity.Warehouse
    };

    public static Talorants.Data.Entities.Category ToEntity(Tolerants.Api.Warehouse.Models.Category.Category model)
    => new()
    {
        Name = model.Name,
        Products = model.Products
    };
}