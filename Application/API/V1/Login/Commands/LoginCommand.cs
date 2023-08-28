using Application.Abstractions.Messaging;
using Application.API.V1.Login.Models;

namespace Application.API.V1.Login.Commands;

public class LoginCommand : ICommand<LoginModel>
{
    public string Email { get; set; }
    public string Password { get; set; }
    
    public LoginCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }
}