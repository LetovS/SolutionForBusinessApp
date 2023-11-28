using Business.Abstract;
using Business.Abstract.Models;

namespace Business.Models.Order;

public class UpdateOrderItemModel : IUpdateModel
{
    public UpdateOrderItemModel(
        int orderId,
        string name,
        decimal quantity,
        string unit)
    {
        OrderId = orderId;
        Name = name;
        Quantity = quantity;
        Unit = unit;
    }
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