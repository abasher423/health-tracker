using System.Text.RegularExpressions;
using Application.API.V1.Login.Models;
using FluentValidation;

namespace Application.API.V1.Login.Commands;

public class LoginCommandValidator : AbstractValidator<LoginRequest>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty()
            .MaximumLength(254)
            .Must(ValidEmail)
            .WithMessage("Please enter a valid email address");

        RuleFor(x => x.Password).NotEmpty()
            .MaximumLength(100);
    }
    
    private bool ValidEmail(string email)
    {
        string regexPattern = @"^[\w\.-]+@[\w\.-]+\.\w+$";
        return Regex.IsMatch(email, regexPattern);
    }
}