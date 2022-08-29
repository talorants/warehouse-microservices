using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Talorants.Data.Entities.Configuration;

public class WarehouseConfiguration : EntityBaseConfiguration<Warehouse>
{
    public override void Configure(EntityTypeBuilder<Warehouse> builder)
    {
        base.Configure(builder);

        builder.Property(b => b.Name).IsRequired(true);
        builder.Property(b => b.Adress).IsRequired(true);
    }
}