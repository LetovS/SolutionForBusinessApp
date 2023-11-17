using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Entities;

namespace Store.EntityConfiguration;

public class ProviderConfiguration : IEntityTypeConfiguration<ProviderRecord>
{
    private const string ProviderNameIndex = "UQ_Provider_Name";
    private const int MaxFieldLength = 255;
    public void Configure(EntityTypeBuilder<ProviderRecord> builder)
    {
        builder.ConfigureBaseEntity<ProviderRecord>();

        builder.Property(x => x.Name).HasMaxLength(MaxFieldLength);
        builder.HasIndex(x => x.Name).HasDatabaseName(ProviderNameIndex).IsUnique();
    }
}
