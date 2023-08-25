using Persistence.Configurations.Context;

namespace Persistence;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly HealthTrackerDbContext _dbContext;

    public UnitOfWork(HealthTrackerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}