namespace RinhaBackend2023Q3.Domain.Interfaces.Infra.Context;

public interface IUnitOfWork : IAsyncDisposable
{
    Task CommitAsync();
}
