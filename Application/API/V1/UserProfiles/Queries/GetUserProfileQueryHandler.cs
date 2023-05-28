using Application.API.V1.UserProfiles.Models;
using Application.Repositories.UserProfile;
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
        if (request == null || request.Id == Guid.Empty)
        {
            throw new ArgumentNullException();
        }
        
        return await _userProfileRepository.GetSingleUserProfile(request.Id, cancellationToken);
    }
}