using System.ComponentModel.DataAnnotations;
using Talorants.Api.User.Model;

namespace Tolerants.Api.Warehouse.Dtos.Warehouse;

public class CreateWarehouse
{
    [Required]
    [MaxLength(56)]
    public string? Name { get; set; }
    
    [Required]
    public string? Adress { get; set; }
    
    public virtual ICollection<User>? Users { get; set; }
    
    public virtual ICollection<Talorants.Data.Entities.Product>? Products { get; set; }
}