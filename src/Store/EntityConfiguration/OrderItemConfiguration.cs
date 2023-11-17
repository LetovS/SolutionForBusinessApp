using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Entities;

namespace Store.EntityConfiguration;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItemRecord>
{
    private const int MaxFieldLength = 255;
    public void Configure(EntityTypeBuilder<OrderItemRecord> builder)
    {
        builder.ConfigureBaseEntity<OrderItemRecord>();

        
        builder.Property(x => x.Unit).HasMaxLength(MaxFieldLength).IsRequired();
        builder.Property(x => x.Name).HasMaxLength(MaxFieldLength).IsRequired();
        builder.Property(x => x.Quantity).HasPrecision(18,2).IsRequired();
    }
}
