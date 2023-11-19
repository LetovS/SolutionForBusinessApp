using Store.Entities.Base;

namespace Store.Repositories.Abstracts;

public interface IProviderRepository<T> : IBaseRepository<T>
    where T : BaseEntity
{
    
}