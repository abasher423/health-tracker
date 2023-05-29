using Application.API.V1.UserProfile.Models;
using Common.Enums;
using MediatR;

namespace Application.API.V1.UserProfile.Commands.Update;

public class UpdateUserProfileCommand : IRequest<UpdateUserProfileModel>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public decimal Height { get; set; }
    public decimal Weight { get; set; }
}