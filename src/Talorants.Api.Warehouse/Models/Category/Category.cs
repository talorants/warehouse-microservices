namespace Tolerants.Api.Warehouse.Models.Category;

public class Category
{
    public string? Name { get; set; }
    public virtual ICollection<Talorants.Data.Entities.Product>? Products { get; set; }
}