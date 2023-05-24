using Application.API.V1.UserProfiles.Models;
using MediatR;

namespace Application.API.V1.UserProfiles.Queries;

public class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQuery, UserProfileDto>
{
    private readonly IUserProfileRepository _userProfileRepository;
    
    public GetUserProfileQueryHandler(IUserProfileRepository userProfileRepository)
    {
        _userProfileRepository = userProfileRepository;
    }
    public async Task<UserProfileDto> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
    {
        var userProfile = await _userProfileRepository.GetSingleUserProfile(request.Id, cancellationToken);

        if (userProfile == null)
        {
            return null;
        }

        return userProfile;
    }
}