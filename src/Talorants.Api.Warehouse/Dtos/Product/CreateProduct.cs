using System.ComponentModel.DataAnnotations;
using Talorants.Data.Entities;

namespace Tolerants.Api.Warehouse.Dtos.Product;

public class CreateProduct
{
    [Required]
    [MaxLength(56)]
    public string? Name { get; set; }

    [Required]
    public int Amount { get; set; }
    
    [Required]
    public double InitialPrice { get; set; }
        
    public Category? Category { get; set; }
    
    public virtual Talorants.Data.Entities.Warehouse? Warehouse { get; set; }
}