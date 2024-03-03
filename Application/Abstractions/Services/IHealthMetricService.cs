using Application.API.V1.HealthMetric.Models;

namespace Application.Abstractions.Services;

public interface IHealthMetricService
{
    Task<IEnumerable<HealthMetricModel>> GetHealthDataEntries(CancellationToken cancellationToken);
    Task<HealthMetricModel> GetHealthDataEntry(Guid id, CancellationToken cancellationToken);
    Task<HealthMetricModel> CreateHealthDataEntry(HealthMetricModel healthMetric, CancellationToken cancellationToken);
    Task<HealthMetricModel> UpdateHealthDataEntry(HealthMetricModel healthMetric, CancellationToken cancellationToken);
    Task<bool> DeleteHealthDataEntry(Guid id, CancellationToken cancellationToken);
}