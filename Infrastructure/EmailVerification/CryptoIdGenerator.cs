using System.Security.Cryptography;

namespace Infrastructure.EmailVerification;

public class CryptoIdGenerator
{
    public static string GenerateCryptoId()
    {
        // Create a byte array that will hold random bytes
        var randomBytes = new Byte[32];
        
        // Generate random bytes
        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            // fills the randomBytes array with cryptographically strong random values
            rng.GetBytes(randomBytes);
        }

        var cryptoId = BitConverter.ToString(randomBytes).Replace("-","").ToLower();

        return cryptoId;
    }
}