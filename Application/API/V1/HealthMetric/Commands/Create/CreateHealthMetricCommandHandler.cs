using Application.Abstractions.Messaging;
using Application.Abstractions.Services;
using Application.API.V1.HealthMetric.Models;
using AutoMapper;

namespace Application.API.V1.HealthMetric.Commands.Create;

public class CreateHealthMetricCommandHandler : ICommandHandler<CreateHealthMetricCommand, HealthMetricModel>
{
    private readonly IHealthMetricService _healthMetricService;
    private readonly IMapper _mapper;

    public CreateHealthMetricCommandHandler(IHealthMetricService healthMetricService, IMapper mapper)
    {
        _healthMetricService = healthMetricService;
        _mapper = mapper;
    }

    public async Task<HealthMetricModel> Handle(CreateHealthMetricCommand request, CancellationToken cancellationToken)
    {
        var mappedEntry = _mapper.Map<HealthMetricModel>(request);
        return await _healthMetricService.CreateHealthDataEntry(mappedEntry, cancellationToken);
    }
}