using Application.Abstractions.Messaging;
using Application.Abstractions.Services;
using Application.API.V1.HealthMetric.Models;

namespace Application.API.V1.HealthMetric.Queries;

public class ListHealthMetricsQueryHandler : IQueryHandler<ListHealthMetricsQuery, IEnumerable<HealthMetricModel>>
{
    private readonly IHealthMetricService _healthMetricService;

    public ListHealthMetricsQueryHandler(IHealthMetricService healthMetricService)
    {
        _healthMetricService = healthMetricService;
    }

    public async Task<IEnumerable<HealthMetricModel>> Handle(ListHealthMetricsQuery request, CancellationToken cancellationToken)
    {
        return await _healthMetricService.GetHealthDataEntries(cancellationToken);
    }
}