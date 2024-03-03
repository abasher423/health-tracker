using Application.Abstractions.Messaging;
using Application.API.V1.HealthMetric.Models;

namespace Application.API.V1.HealthMetric.Queries;

public class ListHealthMetricsQuery : IQuery<IEnumerable<HealthMetricModel>>
{
}