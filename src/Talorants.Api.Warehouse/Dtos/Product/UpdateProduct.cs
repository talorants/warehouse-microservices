using System.ComponentModel.DataAnnotations;
using Talorants.Data.Entities;

namespace Tolerants.Api.Warehouse.Dtos.Product;

public class UpdateProduct
{
    [Required]
    [MaxLength(56)]
    public string? Name { get; set; }
    
    [Required]
    public int Amount { get; set; }
    
    [Required]
    public double InitialPrice { get; set; }
    
    [Required]
    public double? SellingPrice { get; set; }
    
    [Required]
    public Category? Category { get; set; }
    
    [Required]
    public virtual Talorants.Data.Entities.Warehouse? Warehouse { get; set; }
}