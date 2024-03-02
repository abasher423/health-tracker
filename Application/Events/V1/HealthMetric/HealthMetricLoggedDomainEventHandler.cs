using Domain.Events.HealthMetric;
using MediatR;

namespace Application.Events.V1.HealthMetric;

public class HealthMetricLoggedDomainEventHandler : INotificationHandler<HealthMetricCreatedDomainEvent>
{
    public Task Handle(HealthMetricCreatedDomainEvent domainEvent, CancellationToken cancellationToken)
    {
        // When a health metric/data has been logged... what do we want to do?
        
        // Update the planner? 
        
        // Calculate averages (update aggregates - what does that mean?)
        
        // Update relevant read models or projections for querying on the read side
        
        // Trigger notifications or alerts based on the logged health metric
        
        throw new NotImplementedException();
    }
}