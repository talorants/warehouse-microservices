using System.ComponentModel.DataAnnotations;
using Talorants.Data.Entities;  //we should change this namespace to talorants.warehouse

namespace Talorants.Api.User.Dtos;

public class UpdateUser 
{   
    [Required]
    [MaxLength(25)]
    public string? Name { get; set; } 

    [Required]
    [MaxLength(25)]
    public string? Login { get; set; }

    [Required]
    [MaxLength(25)]
    public string? Password { get; set; }
    public string? PhoneNumber { get; set; }
    
    public UserGroup? UserGroup { get; set; }
    public Warehouse? Warehouses { get; set; } 
}