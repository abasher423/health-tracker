using Domain.Entities;

namespace Persistence.Repositories.HealthMetrics;

public interface IHealthMetricRepository
{
    Task<IEnumerable<HealthMetric>> GetAllHealthDataEntries(CancellationToken cancellationToken);
    Task<HealthMetric> GetSingleHealthDataEntry(Guid id, CancellationToken cancellationToken);
    Task<HealthMetric> CreateHealthDataEntry(HealthMetric healthMetric, CancellationToken cancellationToken);
    Task<HealthMetric> UpdateHealthDataEntry(HealthMetric healthMetric, CancellationToken cancellationToken);
    Task<bool> DeleteHealthDataEntry(Guid id, CancellationToken cancellationToken);
}