namespace Talorants.Shared.Models;

public class UserGroup
{
    public string? Name { get; set; }
    public ushort Id { get; set; }
    public ICollection<User>? Users { get; set; }
}