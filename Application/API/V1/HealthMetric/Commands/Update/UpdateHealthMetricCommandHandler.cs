using Application.Abstractions.Messaging;
using Application.Abstractions.Services;
using Application.API.V1.HealthMetric.Models;
using AutoMapper;

namespace Application.API.V1.HealthMetric.Commands.Update;

public class UpdateHealthMetricCommandHandler : ICommandHandler<UpdateHealthMetricCommand, HealthMetricModel>
{
    private readonly IHealthMetricService _healthMetricService;
    private readonly IMapper _mapper;

    public UpdateHealthMetricCommandHandler(IHealthMetricService healthMetricService, IMapper mapper)
    {
        _healthMetricService = healthMetricService;
        _mapper = mapper;
    }

    public async Task<HealthMetricModel> Handle(UpdateHealthMetricCommand request, CancellationToken cancellationToken)
    {
        var mappedRequest = _mapper.Map<HealthMetricModel>(request);
        return await _healthMetricService.UpdateHealthDataEntry(mappedRequest, cancellationToken);
    }
}