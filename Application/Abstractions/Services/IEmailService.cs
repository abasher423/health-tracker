using Application.API.V1.Register.Models;

namespace Application.Abstractions.Services;

public interface IEmailService
{ 
    Task SendEmailAsync(string emailAddress, string subject, string body);
    EmailVerificationToken GenerateEmailToken();
    string GenerateVerificationLink(string token);
}