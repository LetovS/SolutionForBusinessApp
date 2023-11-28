using Store.Entities;
using Store.Repositories.Abstracts;

namespace Store.Repositories.Implementations;

/// <summary>
/// Репозиторий провайдеров
/// </summary>
public class ProviderRepository : BaseRepository<ProviderRecord>
{
    public ProviderRepository(IResourceContext dbContext) : base(dbContext)
    {
    }
}