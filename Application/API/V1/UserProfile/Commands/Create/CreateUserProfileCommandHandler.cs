using Application.Abstractions;
using Application.API.V1.UserProfile.Models;
using AutoMapper;
using MediatR;

namespace Application.API.V1.UserProfile.Commands.Create;

public class CreateUserProfileCommandHandler : IRequestHandler<CreateUserProfileCommand, UserProfileModel>
{ 
    // we will use a repository for data access so we can unit test better
    private readonly IProfileService _profileService;
    private readonly IMapper _mapper;
    
    public CreateUserProfileCommandHandler(IProfileService profileService, IMapper mapper)
    {
        _profileService = profileService;
        _mapper = mapper;
    }

    public async Task<UserProfileModel> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException();
        }

        var profile = _mapper.Map<UserProfileModel>(request);

        return await _profileService.CreateProfile(profile, cancellationToken);
    }
}