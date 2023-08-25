using Application.Abstractions.Services;
using MediatR;

namespace Application.API.V1.Verification.Commands;

public class VerifyEmailCommandHandler : IRequestHandler<VerifyEmailCommand, bool>
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