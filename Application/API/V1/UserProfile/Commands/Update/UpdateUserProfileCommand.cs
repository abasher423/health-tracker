using Application.API.V1.UserProfile.Models;
using Common.Enums;
using MediatR;

namespace Application.API.V1.UserProfile.Commands.Update;

public class UpdateUserProfileCommand : IRequest<UpdateUserProfileDto>
{
    public Guid Id { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public decimal Height { get; set; }
    public decimal Weight { get; set; }
}