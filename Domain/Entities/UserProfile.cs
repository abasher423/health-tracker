using Common.Enums;

namespace Domain.Entities;

public class UserProfile : TableAudit
{
    public Guid Id { get; set; }
    
    public int Age { get; set; }
    
    public Gender Gender { get; set; }
    
    public decimal Height { get; set; }
    
    public decimal Weight { get; set; }
    
    public ICollection<HealthMetric> HealthMetrics { get; set; }
}