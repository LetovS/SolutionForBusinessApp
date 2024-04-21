using Store.Entities;
using Store.Repositories.Abstracts;

namespace Store.Repositories.Implementations;

/// <summary>
/// Репозиторий заказов
/// </summary>
public class OrderRepository : BaseRepository<OrderRecord>
{
    public OrderRepository(IResourceContext dbContext) : base(dbContext)
    {
    }
}