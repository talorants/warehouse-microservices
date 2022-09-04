namespace Talorants.Data.Entities;

public class User : EntityBase
{
    public User()
    {
        this.Warehouses = new HashSet<Warehouse>();
    }

    public string? Name { get; set; }
    public string? NameHash { get; set; }
    public string? Login { get; set; }
    public string? Password { get; set; }
    public string? PhoneNumber { get; set; }
    public Warehouse? Warehouse { get; set; }
    public virtual UserGroup? UserGroup { get; set; }
    public virtual ICollection<Warehouse>? Warehouses { get; set; }
}