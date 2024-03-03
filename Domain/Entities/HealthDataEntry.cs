using Common.Enums;
using Domain.Events.HealthMetric;

namespace Domain.Entities;

public class HealthDataEntry : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid HealthMetricId { get; set; }
    public HealthDataName Name { get; set; }
    public decimal Value { get; set; }
    public User User { get; set; }
    public HealthMetric HealthMetric { get; set; }

    public HealthDataEntry()
    {
    }

    public HealthDataEntry(Guid id, Guid userId, Guid healthMetricId, HealthDataName name, decimal value)
    {
        Id = id;
        UserId = userId;
        HealthMetricId = healthMetricId;
        Name = name;
        Value = value;
        
        // Add the OrderStarterDomainEvent to the domain events collection 
        // to be raised/dispatched when committing changes into the Database [ After DbContext.SaveChanges() ]
        AddHealthMetricCreatedDomainEvent(id, userId, healthMetricId, name, value);
    }

    private void AddHealthMetricCreatedDomainEvent(Guid id, Guid userId, Guid healthMetricId, HealthDataName name,
        decimal value)
    {
        var healthMetricCreatedDomainEvent =
            new HealthMetricCreatedDomainEvent(id, userId, healthMetricId, value, name);
        
        this.AddDomainEvent(healthMetricCreatedDomainEvent);
    }
}