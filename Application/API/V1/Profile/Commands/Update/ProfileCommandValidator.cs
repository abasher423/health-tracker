using Application.API.V1.Profile.Models;
using FluentValidation;

namespace Application.API.V1.Profile.Commands.Update;

public class ProfileCommandValidator : AbstractValidator<UpdateUserProfileModel>
{
    public ProfileCommandValidator()
    {
        RuleFor(profile => profile.Age).InclusiveBetween(18, 100);
        
        RuleFor(profile => profile.Height).InclusiveBetween(5, 300);
        
        RuleFor(profile => profile.Gender).IsInEnum();
        
        RuleFor(profile => profile.Weight).InclusiveBetween(10, 500);
    }
}