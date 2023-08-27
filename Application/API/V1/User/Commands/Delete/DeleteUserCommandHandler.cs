using Application.Abstractions.Messaging;
using Application.Abstractions.Services;

namespace Application.API.V1.User.Commands.Delete;

public class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand, bool>
{
    private readonly IUserService _userService;

    public DeleteUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }
    
    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        if (request == null || request.Id == Guid.Empty)
        {
            return false;
        }

        return await _userService.DeleteUser(request.Id, cancellationToken);
    }
}