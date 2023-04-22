using Common.Enums;

namespace Domain.Entities;

public class HealthDataEntry : TableAudit
{
    public Guid Id { get; set; }
    
    public HealthDataName Name { get; set; }
    
    public decimal Value { get; set; }

    public HealthMetric HealthMetric { get; set; }
    
    public ICollection<Goal> Goals { get; set; }
}