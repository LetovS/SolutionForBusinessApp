using Store.Entities.Base;
using Store.Entities.Base.Interfaces;

namespace Store.Repositories.Abstracts;

public interface IBaseRepository<T> where T : BaseEntity
{
    /// <summary>
    /// Получить сущность по ИД
    /// </summary>
    /// <param name="id">ИД</param>
    /// <returns>Сущность</returns>
    public Task<T> GetByIdAsync(int id, CancellationToken ct = default);
    
    /// <summary>
    /// Получить все записи
    /// </summary>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<IReadOnlyList<T>> GetAllAsync(CancellationToken ct = default);
    
    /// <summary>
    /// Получить сущности
    /// </summary>
    /// <param name="offset">Пропускаемое кол-во</param>
    /// <param name="limit">Размер выборки</param>
    /// <returns>Коллекция сущностей</returns>
    public Task<IReadOnlyList<T>> GetWithPaginationAsync(int offset, int limit, CancellationToken ct = default);

    /// <summary>
    /// Создать сущность
    /// </summary>
    /// <param name="data">Модель данных</param>
    public Task CreateAsync(T data, CancellationToken ct = default);

    /// <summary>
    /// Обновить сущность
    /// </summary>
    /// <param name="id">ИД</param>
    /// <param name="data">Данные для обновления</param>
    public Task UpdateAsync(int id, T data, CancellationToken ct = default);

    /// <summary>
    /// Удалить сущность
    /// </summary>
    /// <param name="id">ИД</param>
    public Task<bool> DeleteAsync(int id, CancellationToken ct = default);
}