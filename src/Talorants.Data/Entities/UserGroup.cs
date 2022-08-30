namespace Talorants.Data.Entities;

public class UserGroup
{       
    public UserGroup()
    {
        this.Users = new HashSet<User>();
    }

    public string? Name { get; set; }
    public ushort Id { get; set; }
    public virtual ICollection<User>? Users { get; set; }
}