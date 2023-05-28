using Application.API.V1.UserProfiles.Models;
using Application.Repositories.UserProfile;
using MediatR;

namespace Application.API.V1.UserProfiles.Commands.Update;

public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, UpdateUserProfileDto>
{
    private readonly IUserProfileRepository _userProfileRepository;

    public UpdateUserProfileCommandHandler(IUserProfileRepository userProfileRepository)
    {
        _userProfileRepository = userProfileRepository;
    }
    
    public async Task<UpdateUserProfileDto> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException();
        }
        
        var updatedUserProfile = await _userProfileRepository.UpdateUserProfile(request, cancellationToken);

        return updatedUserProfile;
    }
}