using Application.API.V1.User.Models;
using MediatR;

namespace Application.API.V1.User.Commands.Update;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserModel>
{
    private IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<UpdateUserModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException();
        }

        return await _userRepository.UpdateUser(request, cancellationToken);
    }
}