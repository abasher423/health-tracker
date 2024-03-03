using Application.Abstractions.Messaging;
using Application.Abstractions.Services;
using Application.API.V1.HealthMetric.Models;

namespace Application.API.V1.HealthMetric.Queries;

public class GetHealthMetricQueryHandler : IQueryHandler<GetHealthMetricQuery, HealthMetricModel>
{
    private readonly IHealthMetricService _healthMetricService;

    public GetHealthMetricQueryHandler(IHealthMetricService healthMetricService)
    {
        _healthMetricService = healthMetricService;
    }

    public async Task<HealthMetricModel> Handle(GetHealthMetricQuery request, CancellationToken cancellationToken)
    {
        return await _healthMetricService.GetHealthDataEntry(request.Id, cancellationToken);
    }
}