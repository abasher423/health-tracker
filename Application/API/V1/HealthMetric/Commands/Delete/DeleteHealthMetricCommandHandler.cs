using Application.Abstractions.Messaging;
using Application.Abstractions.Services;
using AutoMapper;

namespace Application.API.V1.HealthMetric.Commands.Delete;

public class DeleteHealthMetricCommandHandler : ICommandHandler<DeleteHealthMetricCommand, bool>
{
    private readonly IHealthMetricService _healthMetricService;

    public DeleteHealthMetricCommandHandler(IHealthMetricService healthMetricService, IMapper mapper)
    {
        _healthMetricService = healthMetricService;
    }

    public async Task<bool> Handle(DeleteHealthMetricCommand request, CancellationToken cancellationToken)
    {
        return await _healthMetricService.DeleteHealthDataEntry(request.Id, cancellationToken);
    }
}