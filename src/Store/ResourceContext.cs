using Microsoft.EntityFrameworkCore;
using Store.Entities;

namespace Store;

public class ResourceContext : DbContext, IResourceContext
{
    public ResourceContext(DbContextOptions opts) : base(opts)
    {
    }

    /// <inheritdoc/>
    public DbSet<OrderRecord> Orders => Set<OrderRecord>();

    /// <inheritdoc/>
    public DbSet<OrderItemRecord> OrderItems => Set<OrderItemRecord>();

    /// <inheritdoc/>
    public DbSet<ProviderRecord> Providers => Set<ProviderRecord>();

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
