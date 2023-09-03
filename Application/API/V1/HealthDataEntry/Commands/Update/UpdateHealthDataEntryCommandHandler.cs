using Application.Abstractions.Messaging;
using Application.Abstractions.Services;
using Application.API.V1.HealthDataEntry.Models;
using AutoMapper;
using Common.Exceptions;

namespace Application.API.V1.HealthDataEntry.Commands.Update;

public class UpdateHealthDataEntryCommandHandler : ICommandHandler<UpdateHealthDataEntryCommand, HealthDataEntryModel>
{
    private readonly IHealthDataEntryService _healthDataEntryService;
    private readonly IMapper _mapper;

    public UpdateHealthDataEntryCommandHandler(IHealthDataEntryService healthDataEntryService, IMapper mapper)
    {
        _healthDataEntryService = healthDataEntryService;
        _mapper = mapper;
    }

    public async Task<HealthDataEntryModel> Handle(UpdateHealthDataEntryCommand request, CancellationToken cancellationToken)
    {
        var mappedRequest = _mapper.Map<HealthDataEntryModel>(request);
        return await _healthDataEntryService.UpdateHealthDataEntry(mappedRequest, cancellationToken);
    }
}