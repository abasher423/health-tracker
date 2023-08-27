using System.Text.RegularExpressions;
using Application.API.V1.Register.Models;
using FluentValidation;

namespace Application.API.V1.Register.Commands;

public class RegisterCommandValidator : AbstractValidator<RegisterRequest>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);

        RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);

        RuleFor(x => x.Password).NotEmpty().MaximumLength(100);

        RuleFor(x => x.Email)
            .NotEmpty()
            .Must(ValidEmail)
            .WithMessage("Please enter a valid email address");
    }

    private bool ValidEmail(string email)
    {
        string regexPattern = @"^[\w\.-]+@[\w\.-]+\.\w+$";
        return Regex.IsMatch(email, regexPattern);
    }
}