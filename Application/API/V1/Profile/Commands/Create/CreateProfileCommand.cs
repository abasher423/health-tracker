using Application.Abstractions.Messaging;
using Application.API.V1.Profile.Models;
using Common.Enums;

namespace Application.API.V1.Profile.Commands.Create;

public class CreateProfileCommand : ICommand<UserProfileModel>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public decimal Height { get; set; }
    public decimal Weight { get; set; }

    public CreateProfileCommand(CreateUserProfileModel profile)
    {
        UserId = profile.UserId;
        Age = profile.Age;
        Gender = profile.Gender;
        Height = profile.Height;
        Weight = profile.Weight;
    }
}