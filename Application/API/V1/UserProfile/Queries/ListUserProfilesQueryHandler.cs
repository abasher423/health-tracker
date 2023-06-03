using Application.API.V1.UserProfile.Models;
using Application.Repositories.UserProfile;
using MediatR;

namespace Application.API.V1.UserProfile.Queries;

public class ListUserProfilesQueryHandler : IRequestHandler<ListUserProfilesQuery, IEnumerable<UserProfileModel>>
{
    private readonly IUserProfileRepository _userProfileRepository;

    public ListUserProfilesQueryHandler(IUserProfileRepository userProfileRepository)
    {
        _userProfileRepository = userProfileRepository;
    }
    
    public async Task<IEnumerable<UserProfileModel>> Handle(ListUserProfilesQuery request, CancellationToken cancellationToken)
    {
        return await _userProfileRepository.GetAllUserProfiles(cancellationToken);
    }
}