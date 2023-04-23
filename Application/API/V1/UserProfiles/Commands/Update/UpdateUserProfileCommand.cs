using Application.API.V1.UserProfiles.Models;
using Common.Enums;
using MediatR;

namespace Application.API.V1.UserProfiles.Commands.Update;

public class UpdateUserProfileCommand : IRequest<UpdateUserProfileDto>
{
    public Guid Id { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public decimal Height { get; set; }
    public decimal Weight { get; set; }
}