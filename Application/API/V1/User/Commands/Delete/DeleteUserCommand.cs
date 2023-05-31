using MediatR;

namespace Application.API.V1.User.Commands.Delete;

public class DeleteUserCommand : IRequest<bool>
{
    public Guid Id { get; set; }

    public DeleteUserCommand(Guid id)
    {
        Id = id;
    }
}