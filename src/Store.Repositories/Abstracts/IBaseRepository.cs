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
    public Task<T> Get(int id);

    /// <summary>
    /// Получить сущности
    /// </summary>
    /// <param name="offset">Пропускаемое кол-во</param>
    /// <param name="limite">Размер выборки</param>
    /// <returns>Коллекция сущностей</returns>
    public Task<IReadOnlyCollection<T>> GetAll(int offset, int limite);

    /// <summary>
    /// Создать сущность
    /// </summary>
    /// <param name="data">Модель данных</param>
    public Task Create(T data);

    /// <summary>
    /// Обновить сущность
    /// </summary>
    /// <param name="id">ИД</param>
    /// <param name="data">Данные для обновления</param>
    public Task Update(int id, T data);

    /// <summary>
    /// Удалить сущность
    /// </summary>
    /// <param name="id">ИД</param>
    public Task Delete(int id);
}