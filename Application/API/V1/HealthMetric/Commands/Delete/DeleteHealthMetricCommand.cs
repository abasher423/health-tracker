using Application.Abstractions.Messaging;

namespace Application.API.V1.HealthMetric.Commands.Delete;

public class DeleteHealthMetricCommand : ICommand<bool>
{
    public Guid Id { get; set; }

    public DeleteHealthMetricCommand(Guid id)
    {
        Id = id;
    }
}