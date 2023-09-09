using Application.Abstractions.Messaging;
using Application.Abstractions.Services;
using Application.API.V1.HealthDataEntry.Models;
using AutoMapper;
using Common.Exceptions;

namespace Application.API.V1.HealthDataEntry.Commands.Create;

public class CreateHealthDataEntryCommandHandler : ICommandHandler<CreateHealthDataEntryCommand, HealthDataEntryModel>
{
    private readonly IHealthDataEntryService _healthDataEntryService;
    private readonly IMapper _mapper;

    public CreateHealthDataEntryCommandHandler(IHealthDataEntryService healthDataEntryService, IMapper mapper)
    {
        _healthDataEntryService = healthDataEntryService;
        _mapper = mapper;
    }

    public async Task<HealthDataEntryModel> Handle(CreateHealthDataEntryCommand request, CancellationToken cancellationToken)
    {
        var mappedRequest = _mapper.Map<HealthDataEntryModel>(request);
        return await _healthDataEntryService.CreateHealthDataEntry(mappedRequest, cancellationToken);
    }
}