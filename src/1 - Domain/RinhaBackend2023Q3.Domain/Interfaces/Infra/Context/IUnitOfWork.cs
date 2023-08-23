namespace RinhaBackend2023Q3.Domain.Interfaces.Infra.Context;

public interface IUnitOfWork : IDisposable
{
    void Commit();
    void Rollback();
    //Task<int> SaveAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys);
}
