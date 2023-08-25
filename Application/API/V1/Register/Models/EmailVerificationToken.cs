namespace Application.API.V1.Register.Models;

public class EmailVerificationToken
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
}