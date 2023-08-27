using Application.Abstractions.Messaging;
using Application.Abstractions.Services;
using Application.API.V1.UserProfile.Models;

namespace Application.API.V1.UserProfile.Queries;

public class ListUserProfilesQueryHandler : IQueryHandler<ListUserProfilesQuery, IEnumerable<UserProfileModel>>
{
    private readonly IProfileService _profileService;

    public ListUserProfilesQueryHandler(IProfileService profileService)
    {
        _profileService = profileService;
    }
    
    public async Task<IEnumerable<UserProfileModel>> Handle(ListUserProfilesQuery request, CancellationToken cancellationToken)
    {
        return await _profileService.GetProfiles(cancellationToken);
    }
}