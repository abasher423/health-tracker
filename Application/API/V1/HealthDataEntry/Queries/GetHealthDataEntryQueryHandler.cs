using Application.Abstractions.Messaging;
using Application.Abstractions.Services;
using Application.API.V1.HealthDataEntry.Models;

namespace Application.API.V1.HealthDataEntry.Queries;

public class GetHealthDataEntryQueryHandler : IQueryHandler<GetHealthDataEntryQuery, HealthDataEntryModel>
{
    private readonly IHealthDataEntryService _healthDataEntryService;

    public GetHealthDataEntryQueryHandler(IHealthDataEntryService healthDataEntryService)
    {
        _healthDataEntryService = healthDataEntryService;
    }

    public async Task<HealthDataEntryModel> Handle(GetHealthDataEntryQuery request, CancellationToken cancellationToken)
    {
        return await _healthDataEntryService.GetHealthDataEntry(request.Id, cancellationToken);
    }
}