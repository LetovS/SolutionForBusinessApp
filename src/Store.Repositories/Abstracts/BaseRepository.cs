using Microsoft.EntityFrameworkCore;
using Store.Entities.Base;
using Store.Entities.Base.Interfaces;

namespace Store.Repositories.Abstracts;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> 
    where TEntity : BaseEntity, IEntityWithId
{
    private readonly IResourceContext _dbContext;
    private DbSet<TEntity> EntitySet => _dbContext.Set<TEntity>();

    protected BaseRepository(IResourceContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<TEntity> GetByIdAsync(int id, CancellationToken ct)
    {
        var entity = await AdjustQuery(EntitySet)
            .FirstOrDefaultAsync(x => x.Id == id, ct);
        return entity;
    }

    public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken ct) =>
        await GetAdjustedAndOrderedQuery()
            .ToListAsync(ct);
    
    
    public async Task<IReadOnlyList<TEntity>> GetWithPaginationAsync(
        int offset,
        int limit,
        CancellationToken ct)
    {
        return await GetAdjustedAndOrderedQuery()
            .Skip(offset)
            .Take(limit)
            .ToListAsync(ct);
    }

    public async Task CreateAsync(TEntity data, CancellationToken ct)
    {
        var dbEntity = await EntitySet.FirstOrDefaultAsync(x => x.Id == data.Id, ct);
        if (dbEntity is  null) return;
        EntitySet.Add(dbEntity);
        await _dbContext.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(int id, TEntity data, CancellationToken ct)
    {
        var dbEntity = await EntitySet.FirstOrDefaultAsync(x => x.Id == data.Id, ct);
        if (dbEntity is null) return;
        EntitySet.Update(dbEntity);
        await _dbContext.SaveChangesAsync(ct);
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken ct)
    {
        var entity = await EntitySet.FirstOrDefaultAsync(x => x.Id == id, ct);
        if (entity is null) return false;
        EntitySet.Remove(entity);
        await _dbContext.SaveChangesAsync(ct);
        return true;
    }
    protected virtual IQueryable<TEntity> AdjustQuery(IQueryable<TEntity> query) 
        => query;
    
    protected virtual IOrderedQueryable<TEntity> OrderQuery(IQueryable<TEntity> query) 
        => query.OrderBy(x => x.Id);
    
    private IOrderedQueryable<TEntity> GetAdjustedAndOrderedQuery()
    {
        return OrderQuery(AdjustQuery(EntitySet));
    }
}