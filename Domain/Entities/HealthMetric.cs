using Common.Enums;

namespace Domain.Entities;

public class HealthMetric : TableAudit
{
    public Guid Id { get; set; }
    
    public HealthMetricType Type { get; set; }
    
    public string UnitOfMeasurement { get; set; }
    
    // allows us to link the same userprofile to many different health metrics
    public UserProfile UserProfile { get; set; }
    
    public ICollection<HealthDataEntry> HealthDataEntries { get; set; }
}