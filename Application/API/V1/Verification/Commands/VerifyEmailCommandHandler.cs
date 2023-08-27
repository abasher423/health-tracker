using Application.Abstractions.Messaging;
using Application.Abstractions.Services;

namespace Application.API.V1.Verification.Commands;

public class VerifyEmailCommandHandler : ICommandHandler<VerifyEmailCommand, bool>
{
    private readonly IVerificationService _verificationService;

    public VerifyEmailCommandHandler(IVerificationService verificationService)
    {
        _verificationService = verificationService;
    }

    public async Task<bool> Handle(VerifyEmailCommand request, CancellationToken cancellationToken)
    {
        if (request == null || request.Token == string.Empty)
        {
            throw new ArgumentNullException();
        }

        return await _verificationService.VeryEmail(request.Token, cancellationToken);
    }
}