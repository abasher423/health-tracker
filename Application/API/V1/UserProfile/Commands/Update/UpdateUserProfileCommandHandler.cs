using Application.Abstractions;
using Application.API.V1.UserProfile.Models;
using AutoMapper;
using MediatR;

namespace Application.API.V1.UserProfile.Commands.Update;

public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, UserProfileModel>
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