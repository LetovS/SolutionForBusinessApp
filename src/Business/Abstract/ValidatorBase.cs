using Store.Entities.Base.Interfaces;

namespace Business.Abstract;

public abstract class ValidatorBase<TEntity> : IBusinessValidator<TEntity>
    where TEntity: class, IDbEntity
{
    public virtual async Task<bool> ValidateSave(TEntity entity, CancellationToken ct = default) => await Task.FromResult(true); 

    public virtual async Task<bool> ValidateDelete(int entityId, CancellationToken ct = default) => await Task.FromResult(true);
}