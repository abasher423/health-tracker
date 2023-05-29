using Application.API.V1.UserProfile.Models;
using Application.Repositories.UserProfile;
using MediatR;

namespace Application.API.V1.UserProfile.Commands.Update;

public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, UpdateUserProfileModel>
{
    private readonly IUserProfileRepository _userProfileRepository;

    public UpdateUserProfileCommandHandler(IUserProfileRepository userProfileRepository)
    {
        _userProfileRepository = userProfileRepository;
    }
    
    public async Task<UpdateUserProfileModel> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException();
        }
        
        var updatedUserProfile = await _userProfileRepository.UpdateUserProfile(request, cancellationToken);

        return updatedUserProfile;
    }
}