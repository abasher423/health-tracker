using Application.API.V1.HealthDataEntry.Models;

namespace Application.Abstractions.Services;

public interface IHealthDataEntryService
{
    Task<IEnumerable<HealthDataEntryModel>> GetHealthDataEntries(CancellationToken cancellationToken);
    Task<HealthDataEntryModel> GetHealthDataEntry(Guid id, CancellationToken cancellationToken);
    Task<HealthDataEntryModel> CreateHealthDataEntry(HealthDataEntryModel healthDataEntry, CancellationToken cancellationToken);
    Task<HealthDataEntryModel> UpdateHealthDataEntry(HealthDataEntryModel healthDataEntry, CancellationToken cancellationToken);
    Task<bool> DeleteHealthDataEntry(Guid id, CancellationToken cancellationToken);
}