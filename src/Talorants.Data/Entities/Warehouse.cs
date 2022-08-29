namespace Talorants.Data.Entities;

public class Warehouse : EntityBase
{
    public string? Name { get; set; }
    public string? Adress { get; set; }
    public User? ResponsiblePerson { get; set; }
    public List<Product>? Products { get; set; }
}