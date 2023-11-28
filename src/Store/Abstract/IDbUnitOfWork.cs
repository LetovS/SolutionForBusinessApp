namespace Store.Abstract;

public interface IDbUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    IDbTransaction InTransaction();
}