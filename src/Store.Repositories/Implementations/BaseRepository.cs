using Store.Entities.Base;
using Store.Repositories.Abstracts;

namespace Store.Repositories.Implementations;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    public async Task<T> Get(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyCollection<T>> GetAll(int offset, int limite)
    {
        throw new NotImplementedException();
    }

    public async Task Create(T data)
    {
        throw new NotImplementedException();
    }

    public async Task Update(int id, T data)
    {
        throw new NotImplementedException();
    }

    public async Task Delete(int id)
    {
        throw new NotImplementedException();
    }
}