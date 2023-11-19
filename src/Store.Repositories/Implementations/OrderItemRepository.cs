using Store.Entities;
using Store.Entities.Base;
using Store.Repositories.Abstracts;

namespace Store.Repositories.Implementations;

/// <summary>
/// Репозиторий товара
/// </summary>
public class OrderItemRepository<T> : BaseRepository<T>, IOrderRepository<T> where T : OrderItemRecord
{
    
}