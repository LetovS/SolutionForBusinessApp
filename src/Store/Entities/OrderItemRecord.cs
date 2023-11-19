using Store.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Entities;

public class OrderItemRecord : BaseEntity
{
    public OrderItemRecord(int id, int orderId, string name, decimal quantity, string unit) : base(id)
    {
        OrderId = orderId;
        Name = name;
        Quantity = quantity;
        Unit = unit;
    }

    /// <summary>
    /// ИД заказа
    /// </summary>
    [ForeignKey(nameof(OrderRecord))]
    public int OrderId { get; set; }

    /// <summary>
    /// Название товара
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Цена 
    /// </summary>к
    public decimal Quantity { get; set; }

    public string Unit { get; set; }
}
