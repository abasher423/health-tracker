using MediatR;

namespace Application.API.V1.Verification.Commands;

public class VerifyEmailCommand : IRequest<bool>
{
    public string Token { get; set; }

    public VerifyEmailCommand(string token)
    {
        Token = token;
    }
}