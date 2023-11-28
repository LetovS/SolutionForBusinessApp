namespace Web.Contracts.Models.Order;

public sealed class UpdateOrderRequest
{
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