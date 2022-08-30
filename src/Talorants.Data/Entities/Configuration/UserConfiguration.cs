using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Talorants.Data.Entities.Configuration;

public class UserConfiguration : EntityBaseConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.Property(b => b.Name).IsRequired(true);
        builder.Property(b => b.Login).IsRequired(true);
        builder.Property(b => b.Password).IsRequired(true);
        builder.Property(b => b.PhoneNumber).IsRequired(true);
    }
}
