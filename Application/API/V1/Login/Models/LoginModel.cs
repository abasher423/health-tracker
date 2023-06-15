namespace Application.API.V1.Login.Models;

public class LoginModel
{
    public string Email { get; }

    public LoginModel(string email)
    {
        Email = email;
    }
}