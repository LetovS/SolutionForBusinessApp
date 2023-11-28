using Business.Abstract.Models;
using Store.Entities.Base;
using Store.Entities.Base.Interfaces;

namespace Business.Abstract.Services;

public interface IBaseService<TEntity, TCreateModel, TUpdateModel>
    where TEntity : BaseEntity, IDbEntity, IEntityWithId
    where TCreateModel : ICreateModel
    where TUpdateModel : IUpdateModel
{
    /// <summary>
    /// Получить сущность по ИД
    /// </summary>
    Task<TEntity> GetById(int id, CancellationToken ct = default);
    
    /// <summary>
    /// Создать сущность
    /// </summary>
    Task<int> CreateAsync(int id, TCreateModel createModel, CancellationToken ct = default);
    
    /// <summary>
    /// Обновить сущность
    /// </summary>
    Task<bool> UpdateAsync(int id, TUpdateModel updateModel, CancellationToken ct = default);
    
    /// <summary>
    /// Удалить сущность
    /// </summary>
    Task<bool> DeleteByIdAsync(int id, CancellationToken ct = default);

    /// <summary>
    /// Получить все сущности
    /// </summary>
    Task<IReadOnlyList<TEntity>> GetAll(CancellationToken ct = default);
}