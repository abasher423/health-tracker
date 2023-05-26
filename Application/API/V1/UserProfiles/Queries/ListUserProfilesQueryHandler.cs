using Application.API.V1.UserProfiles.Models;
using MediatR;

namespace Application.API.V1.UserProfiles.Queries;

public class ListUserProfilesQueryHandler : IRequestHandler<ListUserProfilesQuery, IEnumerable<UserProfileDto>>
{
    private readonly IUserProfileRepository _userProfileRepository;

    public ListUserProfilesQueryHandler(IUserProfileRepository userProfileRepository)
    {
        _userProfileRepository = userProfileRepository;
    }
    
    public async Task<IEnumerable<UserProfileDto>> Handle(ListUserProfilesQuery request, CancellationToken cancellationToken)
    {
        return await _userProfileRepository.GetAllUserProfiles(cancellationToken);
    }
}