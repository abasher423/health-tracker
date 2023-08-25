using System.Security.Cryptography;
using Application.Abstractions;
using Application.Abstractions.Services;

namespace Infrastructure.EmailVerification;

public class EmailVerificationTokenGenerator : IEmailVerificationProvider
{
    public string GenerateEmailVerificationToken(DateTime dateTime)
    {
        var cryptoId = CryptoIdGenerator.GenerateCryptoId();

        var token = cryptoId + dateTime.ToString("yyyyMMddHHmmSS");

        return token;
    }
}