namespace Store.Abstract;

public interface IDbReader
{
    IQueryable<TEntity> Read<TEntity>() where TEntity : class, IEntity;
}