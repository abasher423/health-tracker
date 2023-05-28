using Common.Enums;

namespace Domain.Entities;

public class HealthDataEntry : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid HealthMetricId { get; set; }
    public HealthDataName Name { get; set; }
    public decimal Value { get; set; }
    public User User { get; set; }
    public HealthMetric HealthMetric { get; set; }
}