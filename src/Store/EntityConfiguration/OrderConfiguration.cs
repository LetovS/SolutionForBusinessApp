using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Entities;

namespace Store.EntityConfiguration;

public class OrderConfiguration : IEntityTypeConfiguration<OrderRecord>
{
    private const int MaxFieldLength = 255;
    public void Configure(EntityTypeBuilder<OrderRecord> builder)
    {
        builder.ConfigureBaseEntity<OrderRecord>();
        builder.Property(x => x.Number).HasMaxLength(ConstantsConfigurations.MaxFieldLength).IsRequired();
        builder.Property(x => x.ProviderId).IsRequired();
        builder.Property(x => x.Date).IsRequired();
    }
}
