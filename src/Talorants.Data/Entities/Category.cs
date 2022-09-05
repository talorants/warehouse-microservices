using System.ComponentModel.DataAnnotations;

namespace Talorants.Data.Entities;

public class Category
{  
    [Key] 
    public string? Name { get; set; }
    public ICollection<ProductCategory>? ProductCategories { get; set; }
}