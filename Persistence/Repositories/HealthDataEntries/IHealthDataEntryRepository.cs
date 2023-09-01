using Domain.Entities;

namespace Persistence.Repositories.HealthDataEntries;

public interface IHealthDataEntryRepository
{
    Task<IEnumerable<HealthDataEntry>> GetAllHealthDataEntries(CancellationToken cancellationToken);
    Task<HealthDataEntry> GetSingleHealthDataEntry(Guid id, CancellationToken cancellationToken);
    Task<HealthDataEntry> CreateHealthDataEntry(HealthDataEntry healthDataEntry, CancellationToken cancellationToken);
    Task<HealthDataEntry> UpdateHealthDataEntry(HealthDataEntry healthDataEntry, CancellationToken cancellationToken);
    Task<bool> DeleteHealthDataEntry(Guid id, CancellationToken cancellationToken);
}