using Store.Entities.Base;

namespace Store.Repositories.Abstracts;

public interface IOrderRepository<OrderRecord> : IBaseRepository<T>
    where T : BaseEntity
{
    
}