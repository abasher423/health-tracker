using Application.API.V1.Login.Models;
using MediatR;

namespace Application.API.V1.Login.Commands;

public class LoginCommand : IRequest<LoginModel>
{
    public string Email { get; }
    public string Password { get; }
    
    public LoginCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }
}