using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Entities.Base;

namespace Store.EntityConfiguration;

internal static class EntityConfigurationExtensions
{
    /// <summary>
    /// Конфигурирование PK entity <see cref="BaseEntity"/>
    /// </summary>
    public static void ConfigureBaseEntity<TEntity>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : BaseEntity
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedNever();
    }
}
