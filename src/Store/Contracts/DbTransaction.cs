using System.Transactions;
using Store.Abstract;

namespace Store.Contracts;

public class DbTransaction : IDbTransaction, IDisposable
{
    private readonly TransactionScope transactionScope;

    public DbTransaction()
    {
        TransactionOptions transactionOptions = new TransactionOptions
        {
            IsolationLevel = IsolationLevel.ReadCommitted
        };
        transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
    }

    public void Commit()
    {
        transactionScope.Complete();
    }

    public void Dispose()
    {
        transactionScope.Dispose();
    }
}