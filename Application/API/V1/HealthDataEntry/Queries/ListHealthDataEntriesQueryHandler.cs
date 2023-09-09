using Application.Abstractions.Messaging;
using Application.Abstractions.Services;
using Application.API.V1.HealthDataEntry.Models;

namespace Application.API.V1.HealthDataEntry.Queries;

public class ListHealthDataEntriesQueryHandler : IQueryHandler<ListHealthDataEntriesQuery, IEnumerable<HealthDataEntryModel>>
{
    private readonly IHealthDataEntryService _healthDataEntryService;

    public ListHealthDataEntriesQueryHandler(IHealthDataEntryService healthDataEntryService)
    {
        _healthDataEntryService = healthDataEntryService;
    }

    public async Task<IEnumerable<HealthDataEntryModel>> Handle(ListHealthDataEntriesQuery request, CancellationToken cancellationToken)
    {
        return await _healthDataEntryService.GetHealthDataEntries(cancellationToken);
    }
}