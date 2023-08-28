using Application.Abstractions.Messaging;

namespace Application.API.V1.Verification.Commands;

public class VerifyEmailCommand : ICommand<bool>
{
    public string Token { get; set; }

    public VerifyEmailCommand(string token)
    {
        Token = token;
    }
}