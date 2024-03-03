using Common.Enums;

namespace Domain.Entities;

public class HealthMetric : BaseEntity
{
    public HealthMetricType Type { get; set; }
    public string UnitOfMeasurement { get; set; }
    public ICollection<HealthDataEntry> HealthDataEntries { get; set; }

    public HealthMetric()
    {
    }

    public HealthMetric(Guid id, HealthMetricType type, string unitOfMeasurement)
    {
        Id = id;
        Type = type;
        UnitOfMeasurement = unitOfMeasurement;
    }
}