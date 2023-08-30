using Application.Abstractions.Messaging;
using Application.API.V1.Profile.Models;
using Common.Enums;

namespace Application.API.V1.Profile.Commands.Update;

public class ProfileCommand : ICommand<UserProfileModel>
{
    public Guid Id { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public decimal Height { get; set; }
    public decimal Weight { get; set; }

    public ProfileCommand(UpdateUserProfileModel user, Guid id)
    {
        Id = id;
        Age = user.Age;
        Gender = user.Gender;
        Height = user.Height;
        Weight = user.Weight;
    }
}