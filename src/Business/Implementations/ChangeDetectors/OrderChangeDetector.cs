using Business.Abstract;
using Business.Models.Order;
using Store.Entities;

namespace Business.Implementations.ChangeDetectors;

public class OrderChangeDetector : IChangeDetector<OrderRecord, UpdateOrderModel>
{
    public async Task<bool> HasNoChanges(OrderRecord entity, UpdateOrderModel model, CancellationToken token)
    {
        var result =  model.Number.Equals(entity.Number) &&
                          model.ProviderId == entity.ProviderId &&
                          model.Date == entity.Date;
        
        return await Task.FromResult(result);
    }
}