using Store.Entities.Base;

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
    public int OrderId { get; set; }

    public string Name { get; set; }

    /// <summary>
    /// Цена 
    /// </summary>к
    public decimal Quantity { get; set; }

    public string Unit { get; set; }
}
