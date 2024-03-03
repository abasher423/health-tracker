using Application.Abstractions.Messaging;
using Application.API.V1.HealthMetric.Models;
using Common.Enums;

namespace Application.API.V1.HealthMetric.Commands.Update;

public class UpdateHealthMetricCommand : ICommand<HealthMetricModel>
{
    public Guid Id { get; set; }
    public HealthMetricType Type { get; set; }
    public string UnitOfMeasure { get; set; }

    public UpdateHealthMetricCommand(Guid id, HealthMetricType type, string unitOfMeasure)
    {
        Id = id;
        Type = type;
        UnitOfMeasure = unitOfMeasure;
    }
}