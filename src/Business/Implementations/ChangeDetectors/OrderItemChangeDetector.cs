using Business.Abstract;
using Business.Models.Order;
using Store.Entities;

namespace Business.Implementations.ChangeDetectors;

public class OrderItemChangeDetector : IChangeDetector<OrderItemRecord, UpdateOrderItemModel>
{
    public async Task<bool> HasNoChanges(OrderItemRecord entity, UpdateOrderItemModel model, CancellationToken token)
    {
        var result = model.Name.Equals(entity.Name) &&
                         model.Quantity == entity.Quantity &&
                         model.Unit.Equals(entity.Unit) &&
                         model.OrderId == entity.OrderId;
        return await Task.FromResult(result);
    }
}