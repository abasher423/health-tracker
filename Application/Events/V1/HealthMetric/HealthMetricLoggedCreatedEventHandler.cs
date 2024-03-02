using Domain.Events.HealthMetric;
using MediatR;
using Persistence.Repositories.HealthDataEntries;

namespace Application.Events.V1.HealthMetric;

public class HealthMetricLoggedCreatedEventHandler : INotificationHandler<HealthMetricCreatedDomainEvent>
{
    private readonly IHealthDataEntryRepository _healthDataEntryRepository;

    public HealthMetricLoggedCreatedEventHandler(IHealthDataEntryRepository healthDataEntryRepository)
    {
        _healthDataEntryRepository = healthDataEntryRepository;
    }

    public async Task Handle(HealthMetricCreatedDomainEvent domainEvent, CancellationToken cancellationToken)
    {
        // Update relevant read models or projections for querying on the read side
        var healthDataEntry =
            await _healthDataEntryRepository.GetSingleHealthDataEntry(domainEvent.Id, cancellationToken);

        healthDataEntry.Name = domainEvent.Name ?? healthDataEntry.Name;
        healthDataEntry.Value = domainEvent.Value ?? healthDataEntry.Value;

        await _healthDataEntryRepository.UpdateHealthDataEntry(healthDataEntry, cancellationToken);
        
        // When a health metric/data has been logged... what do we want to do?
        
        // Update the planner? 
        
        // Calculate averages (update aggregates - what does that mean?)

        // Trigger notifications or alerts based on the logged health metric
        
        throw new NotImplementedException();
    }
}