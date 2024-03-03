using Application.Abstractions.Messaging;
using Application.API.V1.HealthMetric.Models;

namespace Application.API.V1.HealthMetric.Queries;

public class GetHealthMetricQuery : IQuery<HealthMetricModel>
{
    public Guid Id { get; set; }

    public GetHealthMetricQuery(Guid id)
    {
        Id = id;
    }
}