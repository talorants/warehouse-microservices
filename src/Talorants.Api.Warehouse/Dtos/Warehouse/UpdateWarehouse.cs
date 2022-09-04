using System.ComponentModel.DataAnnotations;
using Talorants.Api.User.Model;

namespace Tolerants.Api.Warehouse.Dtos.Warehouse;

public class UpdateWarehouse
{
    [Required]
    [MaxLength(56)]
    public string? Name { get; set; }
    
    [Required]
    public string? Adress { get; set; }
    
    [Required]
    public virtual ICollection<User>? Users { get; set; }
    
    [Required]
    public virtual ICollection<Talorants.Data.Entities.Product>? Products { get; set; }
}