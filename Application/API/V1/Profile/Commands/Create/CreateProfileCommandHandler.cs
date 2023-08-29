using Application.Abstractions.Messaging;
using Application.Abstractions.Services;
using Application.API.V1.Profile.Models;
using AutoMapper;

namespace Application.API.V1.Profile.Commands.Create;

public class CreateProfileCommandHandler : ICommandHandler<CreateProfileCommand, UserProfileModel>
{ 
    // we will use a repository for data access so we can unit test better
    private readonly IProfileService _profileService;
    private readonly IMapper _mapper;
    
    public CreateProfileCommandHandler(IProfileService profileService, IMapper mapper)
    {
        _profileService = profileService;
        _mapper = mapper;
    }

    public async Task<UserProfileModel> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException();
        }

        var profile = _mapper.Map<UserProfileModel>(request);

        return await _profileService.CreateProfile(profile, cancellationToken);
    }
}