using Common.Enums;

namespace Application.API.V1.HealthMetric.Models;

public class HealthMetricModel
{
    public Guid Id { get; set; }
    public HealthMetricType Type { get; set; }
    public string UnitOfMeasure { get; set; } = string.Empty;
}