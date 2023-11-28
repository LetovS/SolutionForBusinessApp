namespace Store.Abstract;

public interface IDbWriter
{
    void Add<TEntity>(TEntity entity) where TEntity : class, IEntity;

    void Update<TEntity>(TEntity entity) where TEntity : class, IEntity;

    void Delete<TEntity>(TEntity entity) where TEntity : class, IEntity;
}