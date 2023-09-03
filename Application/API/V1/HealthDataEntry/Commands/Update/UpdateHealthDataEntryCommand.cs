using Application.Abstractions.Messaging;
using Application.API.V1.HealthDataEntry.Models;
using Common.Enums;

namespace Application.API.V1.HealthDataEntry.Commands.Update;

public class UpdateHealthDataEntryCommand : ICommand<HealthDataEntryModel>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public HealthDataName Name { get; set; }
    public decimal Value { get; set; }

    public UpdateHealthDataEntryCommand(UpdateHealthDataEntryModel model)
    {
        Id = model.Id;
        UserId = model.UserId;
        Name = model.Name;
        Value = model.Value;
    }
}