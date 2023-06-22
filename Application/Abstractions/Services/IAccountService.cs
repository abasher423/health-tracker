using Application.API.V1.Login.Models;
using Application.API.V1.Register.Models;

namespace Application.Abstractions.Services;

public interface IAccountService
{
    Task<LoginModel> Login(LoginRequest loginRequest, CancellationToken cancellationToken);
    Task<RegisterModel> Register(RegisterRequest user, CancellationToken cancellationToken);
}