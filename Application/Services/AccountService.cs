using Application.Abstractions;
using Application.Abstractions.Services;
using Application.API.V1.Login.Models;
using Application.API.V1.Register.Models;
using Application.API.V1.User.Models;
using AutoMapper;
using Common.Enums;
using Domain.Entities;
using Persistence;
using Persistence.Repositories.Users;

namespace Application.Services;

public class AccountService : IAccountService
{
    private readonly IMapper _mapper;
    private readonly IJwtProvider _jwtProvider;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserRepository _userRepository;
    private readonly IEmailService _emailService;
    private readonly IUnitOfWork _unitOfWork;

    public AccountService(IJwtProvider jwtProvider, IPasswordHasher passwordHasher, IUserRepository userRepository, IMapper mapper, IEmailService emailService, IUnitOfWork unitOfWork)
    {
        _jwtProvider = jwtProvider;
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
        _mapper = mapper;
        _emailService = emailService;
        _unitOfWork = unitOfWork;
    }

    public async Task<LoginModel> Login(LoginRequest loginRequest, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmail(loginRequest.Email, cancellationToken);

        if (user == null)
            return null;
        
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

        if (!await _userRepository.IsEmailUniqueAsync(userToBeCreated.Email, cancellationToken))
        {
            return new RegisterModel()
            {
                Success = false,
                Message = "An account with this email already exists. Please go to log in."
            };
        }

        var token = _emailService.GenerateEmailToken();
        
        userToBeCreated.EmailConfirmed = false;
        userToBeCreated.EmailVerificationToken = token.Token;
        userToBeCreated.EmailVerificationTokenExpiration = token.Expiration;
        userToBeCreated.EmailTokenStatus = TokenStatus.Unused;
        
        var userCreated = await _userRepository.CreateUser(userToBeCreated, cancellationToken);

        if (userCreated != null)
        {
            await _emailService.SendEmailAsync(userCreated.Email, "Email Verification", GetHtmlBody(userCreated.EmailVerificationToken));

            userCreated.EmailTokenStatus = TokenStatus.Pending;

            await _userRepository.UpdateUser(userCreated, cancellationToken);

            return new RegisterModel()
            {
                Success = true,
                Message = "Registration successful. Please check your email for verification instructions."
            };
        }
        else
        {
            return new RegisterModel()
            {
                Success = true,
                Message = "Registration unsuccessful. Unable to create account, please contact support."
            };
        }
        
        
    }
    
    private string GetHtmlBody(string token)
    {
        // Define an HTML template with a placeholder for the token
        string htmlTemplate = @"
            <!DOCTYPE html>
            <html>
            <head>
                <meta charset='UTF-8'>
                <title>Email Verification</title>
            </head>
            <body style='font-family: Arial, Helvetica, sans-serif; background-color: #000; color: #fff; margin: 0; padding: 0;'>
                <div style='background-color: #222; border-radius: 5px; box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1); margin: 20px auto; max-width: 600px; padding: 20px;'>
                    <h1 style='color: #007BFF; font-size: 24px; margin: 0;'>Email Verification</h1>
                    
                    <p style='font-size: 16px; color: #ddd; line-height: 1.5;'>Dear User,</p>
                    
                    <p style='font-size: 16px; color: #ddd; line-height: 1.5;'>Thank you for registering with our service. To complete your registration, please click the following link to verify your email:</p>
                    
                    <p style='font-size: 16px;'><a href='{verificationLink}' style='text-decoration: none; color: #007BFF; font-weight: bold; display: inline-block; background-color: #007BFF; border: none; color: #fff; padding: 10px 20px; text-align: center; font-size: 16px; margin: 10px 0; border-radius: 5px;'>Verify Your Email</a></p>
                    
                    <p style='font-size: 16px; color: #ddd; line-height: 1.5;'>If you did not register for this service, <a href='{invalidationLink}' style='text-decoration: none; color: #007BFF; font-weight: bold;'>click here</a>.</p>
                </div>
                
                <div style='background-color: #000; padding: 10px 0; text-align: center; font-size: 16px;'>
                    &copy; 2023 Health Tracker
                </div>
            </body>
            </html>
            ";

        
        // Replace the placeholder with the actual token
        string htmlBody = htmlTemplate.Replace("{verificationLink}", _emailService.GenerateVerificationLink(token));

        return htmlBody;
    }
}