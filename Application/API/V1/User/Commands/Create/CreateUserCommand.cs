using Application.API.V1.User.Models;
using MediatR;

namespace Application.API.V1.User.Commands.Create;

public class CreateUserCommand : IRequest<UserModel>
{
    public CreateUserCommand(CreateUserModel user)
    {
        Email = user.Email;
        Password = user.Password;
        FirstName = user.FirstName;
        LastName = user.LastName;
    }
    
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}