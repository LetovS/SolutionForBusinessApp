using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Entities;

namespace Store.EntityConfiguration;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItemRecord>
{
    public void Configure(EntityTypeBuilder<OrderItemRecord> builder)
    {
        builder.ConfigureBaseEntity<OrderItemRecord>();
        builder.Property(x => x.Unit).HasMaxLength(ConstantsConfigurations.MaxFieldLength).IsRequired();
        builder.Property(x => x.Name).HasMaxLength(ConstantsConfigurations.MaxFieldLength).IsRequired();
        builder.Property(x => x.Quantity).HasPrecision(18,2).IsRequired();
    }
}
