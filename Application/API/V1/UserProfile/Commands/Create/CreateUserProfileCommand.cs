using Application.API.V1.UserProfile.Models;
using Common.Enums;
using MediatR;

namespace Application.API.V1.UserProfile.Commands.Create;

public class CreateUserProfileCommand : IRequest<UserProfileModel>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public decimal Height { get; set; }
    public decimal Weight { get; set; }

    public CreateUserProfileCommand(CreateUserProfileModel profile)
    {
        UserId = profile.UserId;
        Age = profile.Age;
        Gender = profile.Gender;
        Height = profile.Height;
        Weight = profile.Weight;
    }
}