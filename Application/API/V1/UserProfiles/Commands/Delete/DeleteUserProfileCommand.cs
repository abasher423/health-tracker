using MediatR;

namespace Application.API.V1.UserProfiles.Commands.Delete;

public class DeleteUserProfileCommand : IRequest<bool>
{
    public Guid Id { get; set; }

    public DeleteUserProfileCommand(Guid id)
    {
        Id = id;
    }
}