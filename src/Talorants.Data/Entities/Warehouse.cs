namespace Talorants.Data.Entities;

public class Warehouse : EntityBase
{
    public Warehouse()
    {
        this.Products = new HashSet<Product>();
        this.Users = new HashSet<User>();
    }

    public Warehouse(string? name, string? adress, ICollection<User>? users, ICollection<Product>? products)
    {
        Name = name;
        Adress = adress;
        Users = users;
        Products = products;
    }

    public string? Name { get; set; }
    public string? Adress { get; set; }
    public virtual ICollection<User>? Users { get; set; }
    public virtual ICollection<Product>? Products { get; set; }
}