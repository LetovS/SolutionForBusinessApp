using Store.Entities;
using Store.Entities.Base;
using Store.Repositories.Abstracts;

namespace Store.Repositories.Implementations;

/// <summary>
/// Репозиторий товара
/// </summary>
public class OrderItemRepository : BaseRepository<OrderItemRecord>
{
    public OrderItemRepository(IResourceContext dbContext) : base(dbContext)
    {
    }
}