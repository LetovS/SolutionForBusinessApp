using Business.Abstract;
using Business.Abstract.Models;

namespace Business.Models.Order;

public sealed class UpdateOrderModel : IUpdateModel
{
    public UpdateOrderModel(
        string number,
        DateTime date,
        int providerId)
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