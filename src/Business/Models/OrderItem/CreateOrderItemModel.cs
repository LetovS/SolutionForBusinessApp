using Business.Abstract.Models;

namespace Business.Models.OrderItem;

public sealed class CreateOrderItemModel : ICreateModel
{
    public CreateOrderItemModel(
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
    public int OrderId { get; set; }
    public string Name { get; set; }
    public string Unit { get; set; }
    public decimal Quantity { get; set; }
}