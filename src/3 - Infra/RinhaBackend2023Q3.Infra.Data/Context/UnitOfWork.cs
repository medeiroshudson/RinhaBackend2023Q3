using RinhaBackend2023Q3.Domain.Interfaces.Infra.Context;
using RinhaBackend2023Q3.Infra.Data.Context;

namespace RinhaBackend2023Q3.Infra.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;
    private bool _disposed;

    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public void Commit() => _dbContext.SaveChanges();

    public void Rollback() => _dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        if (disposing && _dbContext != null)
            _dbContext.Dispose();

        _disposed = true;
    }
}
