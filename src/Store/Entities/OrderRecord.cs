using Store.Entities.Base;

namespace Store.Entities;

public class OrderRecord : BaseEntity
{
    public OrderRecord(int id, string number, DateTime date, int providerId) : base(id)
    {
        Number = number;
        Date = date;
        ProviderId = providerId;
    }    

    /// <summary>
    /// Номер заказа
    /// </summary>
    public string Number { get; set; }

    /// <summary>
    /// Дата создания заказа
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// ИД провайдера
    /// </summary>
    public int ProviderId { get; set; }
}
