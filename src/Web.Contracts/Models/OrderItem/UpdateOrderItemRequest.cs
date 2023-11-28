namespace Web.Contracts.Models.OrderItem;

public class UpdateOrderItemRequest
{
    /// <summary>
    /// ИД заказа
    /// </summary>
    public int OrderId { get; set; }

    /// <summary>
    /// Название товара
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Цена 
    /// </summary>к
    public decimal Quantity { get; set; }
    
    /// <summary>
    /// Название чего-то
    /// </summary>
    public string Unit { get; set; }
}