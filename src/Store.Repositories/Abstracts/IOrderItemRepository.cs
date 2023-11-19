using Store.Entities;
using Store.Entities.Base;

namespace Store.Repositories.Abstracts;

public interface IOrderItemRepository : IBaseRepository<T>
    where T : OrderItemRecord
{
    
}