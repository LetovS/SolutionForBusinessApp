namespace Store.Abstract;

public interface IDbTransaction : IDisposable
{
    void Commit();
}