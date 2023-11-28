using Store.Entities.Base.Interfaces;

namespace Business.Abstract;

/// <summary>
/// Валидатор сохранения данных по сущностям БД Ресурсов
/// </summary>
public interface IBusinessValidator<TEntity>
    where TEntity : class, IDbEntity
{
    /// <summary>
    /// Валидация сущности перед сохранением
    /// </summary>
    /// <param name="entity">Сущность</param>
    /// <param name="token">Токен отмены</param>
    Task ValidateSave(TEntity entity, CancellationToken ct = default);

    /// <summary>
    /// Валидация сущности перед удалением
    /// </summary>
    /// <param name="entityId">ИД сущности</param>
    /// <param name="token">Токен отмены</param>
    Task ValidateDelete(Guid entityId, CancellationToken ct = default);
}
