using Application.API.V1.Register.Models;

namespace Application.Abstractions;

public interface IEmailVerificationProvider
{
    string GenerateEmailVerificationToken(DateTime dateTime);
}