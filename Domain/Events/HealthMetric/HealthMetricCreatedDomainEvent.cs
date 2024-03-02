using Common.Enums;
using MediatR;

namespace Domain.Events.HealthMetric;

public class HealthMetricCreatedDomainEvent : INotification
{
    public Guid Id { get; }
    public Guid UserId { get; }
    public Guid HealthMetricId { get; }
    public HealthDataName? Name { get; }
    public decimal? Value { get; }

    public HealthMetricCreatedDomainEvent(Guid id, Guid userId, Guid healthMetricId, decimal value, 
           HealthDataName name)
    {
        Id = id;
        UserId = userId;
        HealthMetricId = healthMetricId;
        Name = name;
        Value = value;
    }
}