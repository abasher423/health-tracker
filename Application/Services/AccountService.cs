using Application.Abstractions;
using Application.Abstractions.Services;
using Application.API.V1.Login.Models;
using Application.API.V1.Register.Models;
using Application.API.V1.User.Models;
using AutoMapper;
using Domain.Entities;
using Persistence.Repositories.Users;

namespace Application.Services;

public class AccountService : IAccountService
{
    private readonly IMapper _mapper;
    private readonly IJwtProvider _jwtProvider;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserRepository _userRepository;

    public AccountService(IJwtProvider jwtProvider, IPasswordHasher passwordHasher, IUserRepository userRepository, IMapper mapper)
    {
        _jwtProvider = jwtProvider;
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
        _mapper = mapper;
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
        var token = _jwtProvider.Generate(_mapper.Map<UserModel>(user));

        return new LoginModel()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Token = token
        };
    }

    public async Task<RegisterModel> Register(RegisterRequest user, CancellationToken cancellationToken)
    {
        var userToBeCreated = new User()
        {
            Email = user.Email,
            HashedPassword = _passwordHasher.Hash(user.Password),
            FirstName = user.FirstName,
            LastName = user.LastName,
        };

        var userCreated = await _userRepository.CreateUser(userToBeCreated, cancellationToken);

        var token = _jwtProvider.Generate(_mapper.Map<UserModel>(userCreated));

        return new RegisterModel()
        {
            FirstName = userCreated.FirstName,
            LastName = userCreated.LastName,
            Token = token
        };
    }
}