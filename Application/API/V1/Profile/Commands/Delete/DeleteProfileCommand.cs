using Application.Abstractions.Messaging;

namespace Application.API.V1.Profile.Commands.Delete;

public class DeleteProfileCommand : ICommand<bool>
{
    public Guid Id { get; set; }

    public DeleteProfileCommand(Guid id)
    {
        Id = id;
    }
}