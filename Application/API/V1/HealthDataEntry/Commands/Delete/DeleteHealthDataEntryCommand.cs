using Application.Abstractions.Messaging;

namespace Application.API.V1.HealthDataEntry.Commands.Delete;

public class DeleteHealthDataEntryCommand : ICommand<bool>
{
    public Guid Id { get; set; }

    public DeleteHealthDataEntryCommand(Guid id)
    {
        Id = id;
    }
}