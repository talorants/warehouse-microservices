namespace Talorants.Data.Entities;

public class User : EntityBase
{
    public string? Name { get; set; }
    public string? NameHash { get; set; }
    public string? Login { get; set; }
    public string? Password { get; set; }
    public string? PhoneNumber { get; set; }
    public ICollection<UserWarehouse>? UserWarehouses { get; set; }
    public UserGroup? UserGroup { get; set; }
}