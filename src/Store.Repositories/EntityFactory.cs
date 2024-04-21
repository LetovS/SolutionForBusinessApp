using Store.Entities;
using Store.Repositories.Abstracts;

namespace Store.Repositories;

public sealed class EntityFactory : IEntityFactory
{
    public OrderItemRecord NewOrderItem(int id, int orderId, string name, decimal quantity, string unit)
    {
        return new OrderItemRecord(id, orderId, name, quantity, unit);
    }

    public OrderRecord NewOrder(int id, string number, DateTime date, int providerId)
    {
        return new OrderRecord(id, number, date, providerId);
    }

    public ProviderRecord NewProvider(int id, string name)
    {
        return new ProviderRecord(id, name);
    }
}