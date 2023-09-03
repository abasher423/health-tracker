using Application.Abstractions.Messaging;
using Application.Abstractions.Services;
using Common.Exceptions;

namespace Application.API.V1.HealthDataEntry.Commands.Delete;

public class DeleteHealthDataEntryCommandHandler : ICommandHandler<DeleteHealthDataEntryCommand, bool>
{
    private readonly IHealthDataEntryService _healthDataEntryService;

    public DeleteHealthDataEntryCommandHandler(IHealthDataEntryService healthDataEntryService)
    {
        _healthDataEntryService = healthDataEntryService;
    }

    public async Task<bool> Handle(DeleteHealthDataEntryCommand request, CancellationToken cancellationToken)
    {
        return await _healthDataEntryService.DeleteHealthDataEntry(request.Id, cancellationToken);
    }
}