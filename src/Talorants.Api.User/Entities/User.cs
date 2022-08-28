using Talorants.Shared.Entities;

namespace Talorants.Api.User.Entities;

public class User : EntityBase
{
    public string? Name { get; set; }
    public Permission? Permission { get; set; }
}