using Application.Abstractions;
using Application.API.V1.UserProfile.Models;
using MediatR;

namespace Application.API.V1.UserProfile.Queries;

public class ListUserProfilesQueryHandler : IRequestHandler<ListUserProfilesQuery, IEnumerable<UserProfileModel>>
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