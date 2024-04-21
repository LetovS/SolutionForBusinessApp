using Store.Entities.Base.Interfaces;

namespace Business.Abstract;

/// <summary>
/// Детектор изменений в модели <see cref="TUpdateModel"/> относительно сущности <see cref="TEntity"/>
/// </summary>
public interface IChangeDetector<in TEntity, in TUpdateModel>
    where TEntity : class, IDbEntity
{
    /// <summary>
    /// Вычислить, эквивалентна ли модель <see cref="TUpdateModel"/> сущности <see cref="TEntity"/>
    /// </summary>
    Task<bool> HasNoChanges(TEntity entity, TUpdateModel model, CancellationToken token);
}
