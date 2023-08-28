using Application.Abstractions.Messaging;

namespace Application.API.V1.UserProfile.Commands.Delete;

public class DeleteUserProfileCommand : ICommand<bool>
{
    public Guid Id { get; set; }

    public DeleteUserProfileCommand(Guid id)
    {
        Id = id;
    }
}