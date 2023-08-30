using Application.Abstractions.Messaging;
using Application.Abstractions.Services;
using Application.API.V1.Profile.Models;
using AutoMapper;
using Common.Exceptions;

namespace Application.API.V1.Profile.Commands.Update;

public class ProfileCommandHandler : ICommandHandler<ProfileCommand, UserProfileModel>
{
    private readonly IMapper _mapper;
    private readonly IProfileService _profileService;

    public ProfileCommandHandler(IProfileService profileService, IMapper mapper)
    {
        _profileService = profileService;
        _mapper = mapper;
    }
    
    public async Task<UserProfileModel> Handle(ProfileCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException();
        }

        if (request.Id == null || request.Id == Guid.Empty)
        {
            throw new ProfileArgumentException("Please provide a valid User ID.");
        }

        var mappedProfile = _mapper.Map<UserProfileModel>(request);
        
        var updatedUserProfile = await _profileService.UpdateProfile(mappedProfile, cancellationToken);

        return updatedUserProfile;
    }
}