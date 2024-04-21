using Microsoft.EntityFrameworkCore;
using Store.Abstract;
using Store.Contracts;
using Store.Entities;

namespace Store;

public class ResourceContext : 
    DbContext,
    IResourceContext,
    IDbReader,
    IDbUnitOfWork,
    IDbWriter
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

    IQueryable<TEntity> IDbReader.Read<TEntity>() => base.Set<TEntity>().AsNoTracking().AsQueryable();

    IDbTransaction IDbUnitOfWork.InTransaction() => new DbTransaction();

    void IDbWriter.Add<TEntity>(TEntity entity) => base.Entry(entity).State = EntityState.Added;

    void IDbWriter.Update<TEntity>(TEntity entity) => base.Entry(entity).State = EntityState.Modified;

    void IDbWriter.Delete<TEntity>(TEntity entity) => base.Entry(entity).State = EntityState.Deleted;
    
    /// <summary>
    /// Сохранить изменения
    /// </summary>
    public override async Task<int> SaveChangesAsync(CancellationToken token = default)
    {
        var count = await base.SaveChangesAsync(token);
       
        foreach (var entry in base.ChangeTracker.Entries().ToArray())
        {
            entry.State = EntityState.Detached;
        }

        return count;
    }
}
