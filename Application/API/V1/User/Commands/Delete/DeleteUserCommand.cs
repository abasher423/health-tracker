using System.Windows.Input;
using Application.Abstractions.Messaging;
using MediatR;

namespace Application.API.V1.User.Commands.Delete;

public class DeleteUserCommand : ICommand<bool>
{
    public Guid Id { get; set; }

    public DeleteUserCommand(Guid id)
    {
        Id = id;
    }
}