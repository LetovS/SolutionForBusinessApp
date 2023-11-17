using Store.Entities.Base.Interfaces;

namespace Store.Entities.Base;

public class BaseEntity : IEntityWithId
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
