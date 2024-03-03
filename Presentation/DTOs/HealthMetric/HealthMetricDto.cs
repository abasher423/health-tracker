using Common.Enums;

namespace HealthTracker.DTOs.HealthMetric;

public class HealthMetricDto
{
    public Guid Id { get; set; }
    public HealthMetricType Type { get; set; }
    public string UnitOfMeasure { get; set; } = string.Empty;
}