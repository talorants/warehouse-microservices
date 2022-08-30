namespace Talorants.Data.Entities;

public class Warehouse : EntityBase
{
    public Warehouse()
    {
        this.Products = new HashSet<Product>();
        this.Users = new HashSet<User>();
    }

    public string? Name { get; set; }
    public string? Adress { get; set; }
    public virtual ICollection<User>? Users { get; set; }
    public virtual ICollection<Product>? Products { get; set; }
}