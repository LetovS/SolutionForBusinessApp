using Store.Entities;
using Store.Entities.Base;
using Store.Repositories.Abstracts;

namespace Store.Repositories.Implementations;

/// <summary>
/// Репозиторий провайдеров
/// </summary>
public class ProviderRepository<T> : IOrderRepository<T> where T : ProviderRecord
{
    
}