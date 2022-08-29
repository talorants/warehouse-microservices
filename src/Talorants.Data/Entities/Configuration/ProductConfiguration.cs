using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Talorants.Data.Entities.Configuration;

public class ProductConfiguration : EntityBaseConfiguration<Product>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
    {
        base.Configure(builder);

        builder.Property(b => b.Name).HasMaxLength(255).IsRequired(true);
        builder.Property(b => b.Amount).IsRequired(true);
        builder.Property(b => b.InitialPrice).IsRequired(true);
        builder.Property(b => b.SellingPrice).IsRequired(true);
    }
}   
    
 