using Application.Abstractions;
using Application.API.V1.Login.Models;
using Application.API.V1.Register.Models;
using Application.API.V1.User.Models;
using Application.Repositories.User;
using Application.Services.Interfaces;
using Domain.Entities;

namespace Application.Services.Implementations;

public class AccountService : IAccountService
{
    private readonly IJwtProvider _jwtProvider;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserRepository _userRepository;

    public AccountService(IJwtProvider jwtProvider, IPasswordHasher passwordHasher, IUserRepository userRepository)
    {
        _jwtProvider = jwtProvider;
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
    }

    public async Task<LoginModel> Login(LoginRequest loginRequest, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmail(loginRequest.Email, cancellationToken);
        
        // Verify hashed passwords
        var result = _passwordHasher.Verify(user.HashedPassword, loginRequest.Password);

        if (!result)
        {
            throw new Exception("Username or password is not correct");
        }
        
        // Generate jwt
        var token = _jwtProvider.Generate(user);

        return new LoginModel()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Token = token
        };
    }

    public async Task<RegisterModel> Register(RegisterRequest user, CancellationToken cancellationToken)
    {
        var userToBeCreated = new UserModel()
        {
            Email = user.Email,
            HashedPassword = _passwordHasher.Hash(user.Password),
            FirstName = user.FirstName,
            LastName = user.LastName,
        };

        var userCreated = await _userRepository.CreateUser(userToBeCreated, cancellationToken);

        var token = _jwtProvider.Generate(userCreated);

        return new RegisterModel()
        {
            FirstName = userCreated.FirstName,
            LastName = userCreated.LastName,
            Token = token
        };
    }
}