using Application.API.V1.Register.Models;
using MediatR;

namespace Application.API.V1.Register.Commands;

public class RegisterCommand : IRequest<RegisterModel>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public RegisterCommand(RegisterRequest request)
    {
        Email = request.Email;
        Password = request.Password;
        FirstName = request.FirstName;
        LastName = request.LastName;
    }
}