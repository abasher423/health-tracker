using Application.Abstractions.Messaging;
using Application.Abstractions.Services;
using Application.API.V1.UserProfile.Models;
using AutoMapper;

namespace Application.API.V1.UserProfile.Commands.Update;

public class UpdateUserProfileCommandHandler : ICommandHandler<UpdateUserProfileCommand, UserProfileModel>
{
    private readonly IMapper _mapper;
    private readonly IProfileService _profileService;

    public UpdateUserProfileCommandHandler(IProfileService profileService, IMapper mapper)
    {
        _profileService = profileService;
        _mapper = mapper;
    }
    
    public async Task<UserProfileModel> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException();
        }

        var mappedProfile = _mapper.Map<UserProfileModel>(request);
        
        var updatedUserProfile = await _profileService.UpdateProfile(mappedProfile, cancellationToken);

        return updatedUserProfile;
    }
}