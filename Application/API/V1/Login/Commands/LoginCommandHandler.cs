using Application.Abstractions;
using Application.Repositories.User;
using MediatR;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.API.V1.Login.Commands;

public sealed class LoginCommandHandler : IRequestHandler<LoginCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtProvider _jwtProvider;

    public LoginCommandHandler(IUserRepository userRepository, IJwtProvider jwtProvider)
    {
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
    }

    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        // Email.Create(request.email)
        
        var user  = await _userRepository.GetByEmail(request.Email, cancellationToken);

        if (user == null)
        {
            return null;
        }
        
        // also check for password

        string token = _jwtProvider.Generate(user);

        return token;

    }
}