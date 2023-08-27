using Application.Abstractions.Messaging;
using Application.API.V1.UserProfile.Models;
using Common.Enums;

namespace Application.API.V1.UserProfile.Commands.Update;

public class UpdateUserProfileCommand : ICommand<UserProfileModel>
{
    public Guid Id { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public decimal Height { get; set; }
    public decimal Weight { get; set; }

    public UpdateUserProfileCommand(UpdateUserProfileModel user, Guid id)
    {
        Id = id;
        Age = user.Age;
        Gender = user.Gender;
        Height = user.Height;
        Weight = user.Weight;
    }
}