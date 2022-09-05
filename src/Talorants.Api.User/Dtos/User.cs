
using Talorants.Data.Entities;  //we should change this namespace to talorants.warehouse

namespace Talorants.Api.User.Dtos;

public class User 
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Login { get; set; }
    public string? Password { get; set; }
    public string? PhoneNumber { get; set; }
    public UserGroup? UserGroup { get; set; }
    public Warehouse? Warehouses { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}