using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace Store.EntityConfiguration;

/// <summary>
/// Расширения для свойств
/// </summary>
public static class PropertyExtensions
{
    /// <summary>
    /// Настроить точность и масштаб свойства
    /// </summary>
    /// <param name="builder">PropertyBuilder</param>
    /// <param name="precision">Точность</param>
    /// <param name="scale">Масштаб</param>
    public static PropertyBuilder<decimal> HasPrecision([NotNull] this PropertyBuilder<decimal> builder, int precision, int scale)
    {
        return builder.HasColumnType($"decimal({precision}, {scale})");
    }

    /// <summary>
    /// Настроить точность и масштаб свойства
    /// </summary>
    /// <param name="builder">PropertyBuilder</param>
    /// <param name="precision">Точность</param>
    /// <param name="scale">Масштаб</param>
    public static PropertyBuilder<decimal?> HasPrecision([NotNull] this PropertyBuilder<decimal?> builder, int precision, int scale)
    {
        return builder.HasColumnType($"decimal({precision}, {scale})");
    }
}
