using System.Text.RegularExpressions;
using Application.API.V1.User.Models;
using FluentValidation;

namespace Application.API.V1.User.Commands.Update;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserModel>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(x => x.FirstName).MaximumLength(50)
            .Must(ValidName)
            .WithMessage("First name should contain only alphabetic characters.");
        
        RuleFor(x => x.LastName).MaximumLength(50)
            .Must(ValidName)
            .WithMessage("Last name should contain only alphabetic characters.");

        RuleFor(x => x.Password).MaximumLength(100)
            .Must(ValidPassword)
            .WithMessage("Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one digit, and one special character.");

        RuleFor(x => x.Email).MaximumLength(254)
            .Must(ValidEmail)
            .WithMessage("Please enter a valid email address");
    }

    private bool ValidName(string name)
    {
        if (!string.IsNullOrEmpty(name))
        {
            string regexPattern = @"^[a-zA-Z]+$";
            return Regex.IsMatch(name, regexPattern);
        }

        return true;
    }
    
    private bool ValidEmail(string email)
    {
        if (!string.IsNullOrEmpty(email))
        {
            string regexPattern = @"^[\w\.-]+@[\w\.-]+\.\w+$";
            return Regex.IsMatch(email, regexPattern);
        }

        return true;
    }

    private bool ValidPassword(string password)
    {
        if (!string.IsNullOrEmpty(password))
        {
            string regexPattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
            return Regex.IsMatch(password, regexPattern);
        }

        return true;
    }
}