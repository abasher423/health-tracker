using MediatR;

namespace Application.API.V1.Login.Commands;

public class LoginCommand : IRequest<string>
{
    public string Email { get; }
    public LoginCommand(string email)
    {
        Email = email;
    }
}