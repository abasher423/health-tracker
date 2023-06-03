using Application.API.V1.User.Models;
using MediatR;

namespace Application.API.V1.User.Commands.Update;

public class UpdateUserCommand : IRequest<UpdateUserModel>
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public UpdateUserCommand(UpdateUserModel user, Guid id)
    {
        Id = id;
        Email = user.Email;
        Password = user.Password;
        FirstName = user.FirstName;
        LastName = user.LastName;
    }
}