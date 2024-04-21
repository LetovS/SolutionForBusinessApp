using Store.Entities.Base.Interfaces;

namespace Store.Entities.Base;

/// <summary>
/// Базовая сущность базы данных
/// </summary>
public class BaseEntity : 
    IDbEntity,
    IEntityWithId
{
    /// <summary>
    /// ИД заказа
    /// </summary>
    public int Id { get; set; }

    public BaseEntity(int id)
    {
        Id = id;
    }
}
