using Store.Entities;
using Store.Entities.Base;
using Store.Repositories.Abstracts;

namespace Store.Repositories.Implementations;

/// <summary>
/// Репозиторий заказов
/// </summary>
public class OrderRepository<OrderRecord> : IOrderRepository<T> where T : OrderRecord
{
    
}