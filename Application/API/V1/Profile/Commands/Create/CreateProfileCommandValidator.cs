using Application.API.V1.Profile.Models;
using FluentValidation;

namespace Application.API.V1.Profile.Commands.Create;

public class CreateProfileCommandValidator : AbstractValidator<CreateUserProfileModel>
{
    public CreateProfileCommandValidator()
    {
        RuleFor(profile => profile.UserId).NotNull();
        
        RuleFor(profile => profile.Age).NotNull().InclusiveBetween(18, 95);
        
        RuleFor(profile => profile.Height).NotNull().InclusiveBetween(5, 300);
        
        RuleFor(profile => profile.Gender).NotNull().IsInEnum();
        
        RuleFor(profile => profile.Weight).NotNull().InclusiveBetween(10, 500);
    }
}