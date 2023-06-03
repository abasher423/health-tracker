using FluentValidation;

namespace Application.API.V1.UserProfile.Commands.Create;

public class CreateUserProfileCommandValidator : AbstractValidator<CreateUserProfileCommand>
{
    public CreateUserProfileCommandValidator()
    {
        //TODO: WHY IS THIS NOT WORKING
        RuleFor(userProfile => userProfile.Age).NotNull().InclusiveBetween(18, 95);
        RuleFor(userProfile => userProfile.Height).NotNull().InclusiveBetween(5, 245);
        RuleFor(userProfile => userProfile.Gender).NotNull().IsInEnum();
        RuleFor(userProfile => userProfile.Weight).NotNull().InclusiveBetween(10, 500);
    }
}