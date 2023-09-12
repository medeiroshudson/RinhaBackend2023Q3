using RinhaBackend2023Q3.Domain.Interfaces.Infra.Context;
using RinhaBackend2023Q3.Infra.Data.Context;

namespace RinhaBackend2023Q3.Infra.Data;

public class UnitOfWork : IUnitOfWork
{
    private bool _disposed;
    private readonly ApplicationDbContext _dbContext;

    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task CommitAsync() => await _dbContext.SaveChangesAsync();

    public async ValueTask DisposeAsync()
    {
        await DisposeAsync(true);
        GC.SuppressFinalize(this);
    }

    protected virtual async ValueTask DisposeAsync(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                await _dbContext.DisposeAsync();
            }

            _disposed = true;
        }
    }
}
