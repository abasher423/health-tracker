using Application.API.V1.User.Models;
using Application.Repositories.User;
using MediatR;

namespace Application.API.V1.User.Commands.Create;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserModel>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException();
        }

        return await _userRepository.CreateUser(request, cancellationToken);
    }
}