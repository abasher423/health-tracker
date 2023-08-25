using Application.Abstractions.Services;
using Common.Enums;
using Domain.Entities;
using Persistence;
using Persistence.Repositories.Users;

namespace Application.Services;

public class VerificationService : IVerificationService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public VerificationService(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> VeryEmail(string token, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailToken(token, cancellationToken);

        if (user == null)
        {
            Console.WriteLine("Unable to find user with the email token provided");
            return false;
        }

        if (CheckTokenStatusFailure(user) && user.EmailTokenStatus != TokenStatus.Pending)
        {
            return false;
        }

        DateTime expirationFromDatabase = user.EmailVerificationTokenExpiration;
        DateTime currentDateTime = DateTime.Now;

        if (expirationFromDatabase > currentDateTime)
        {
            user.EmailTokenStatus = TokenStatus.VerifiedAndLinked;
            user.EmailConfirmed = true;
            Console.WriteLine("Token has successfully been verified");

            await _userRepository.UpdateUser(user, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            
            return true;
        }
        else
        {
            Console.WriteLine("Token has expired");
            user.EmailTokenStatus = TokenStatus.Expired;
            
            await _userRepository.UpdateUser(user, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            
            return false;
        }
    }

    private bool CheckTokenStatusFailure(User user)
    {
        if (user.EmailTokenStatus == TokenStatus.Blocked || user.EmailTokenStatus == TokenStatus.Revoked)
        {
            Console.WriteLine($"Token is set to {user.EmailTokenStatus}. Unable to verify");
            return true;
        }

        if (user.EmailTokenStatus == TokenStatus.Invalid)
        {
            Console.WriteLine("Token is set to invalid. Unable to verify");
            return true;
        }

        if (user.EmailTokenStatus == TokenStatus.Used || user.EmailTokenStatus == TokenStatus.VerifiedAndLinked)
        {
            Console.WriteLine("Token has already been verified");
            return true;
        }

        return false; // No token status failure
    }
}