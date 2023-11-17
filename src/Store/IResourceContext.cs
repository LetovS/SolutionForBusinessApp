using Microsoft.EntityFrameworkCore;
using Store.Entities;

namespace Store;

public interface IResourceContext
{
    /// <summary>
    /// Заказы
    /// </summary>
    public DbSet<OrderRecord> Orders { get; }

    /// <summary>
    /// Элементы заказа
    /// </summary>
    public DbSet<OrderItemRecord> OrderItems { get; }

    /// <summary>
    /// Поставщики
    /// </summary>
    public DbSet<ProviderRecord> Providers { get; }
}
