using Application.Abstractions.Messaging;
using Application.API.V1.HealthDataEntry.Models;
using Common.Enums;

namespace Application.API.V1.HealthDataEntry.Commands.Create;

public class CreateHealthDataEntryCommand : ICommand<HealthDataEntryModel>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid HealthMetricId { get; set; }
    public HealthDataName Name { get; set; }
    public decimal Value { get; set; }

    public CreateHealthDataEntryCommand(CreateHealthDataEntryModel model)
    {
        UserId = model.UserId;
        HealthMetricId = model.HealthMetricId;
        Name = model.Name;
        Value = model.Value;
    }
}