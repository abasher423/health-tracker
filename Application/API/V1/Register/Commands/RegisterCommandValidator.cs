using System.Text.RegularExpressions;
using Application.API.V1.Register.Models;
using FluentValidation;

namespace Application.API.V1.Register.Commands;

public class RegisterCommandValidator : AbstractValidator<RegisterRequest>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50)
            .Matches(@"^[a-zA-Z]+$").WithMessage("First name should contain only alphabetic characters.");

        RuleFor(x => x.LastName).NotEmpty().MaximumLength(50)
            .Matches(@"^[a-zA-Z]+$").WithMessage("Last name should contain only alphabetic characters.");

        RuleFor(x => x.Password).NotEmpty().MaximumLength(100)
            .Must(ValidPassword).WithMessage("Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one digit, and one special character.");

        RuleFor(x => x.Email).NotEmpty().MaximumLength(254)
            .Must(ValidEmail)
            .WithMessage("Please enter a valid email address");
    }

    private bool ValidEmail(string email)
    {
        string regexPattern = @"^[\w\.-]+@[\w\.-]+\.\w+$";
        return Regex.IsMatch(email, regexPattern);
    }

    private bool ValidPassword(string password)
    {
        string regexPattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
        return Regex.IsMatch(password, regexPattern);
    }
}