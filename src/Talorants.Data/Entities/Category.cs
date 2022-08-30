using System.ComponentModel.DataAnnotations;

namespace Talorants.Data.Entities;

public class Category
{   
    public Category()
    {
        this.Products = new HashSet<Product>();
    }

    [Key]
    public string? Name { get; set; }
    public virtual ICollection<Product>? Products { get; set; }
}