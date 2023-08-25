namespace Application.Abstractions.Services;

public interface IVerificationService
{
    Task<bool> VeryEmail(string token, CancellationToken cancellationToken);
}