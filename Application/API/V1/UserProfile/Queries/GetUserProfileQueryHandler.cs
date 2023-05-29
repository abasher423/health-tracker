using Application.API.V1.UserProfile.Models;
using Application.Repositories.UserProfile;
using MediatR;

namespace Application.API.V1.UserProfile.Queries;

public class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQuery, UserProfileModel>
{
    private readonly IUserProfileRepository _userProfileRepository;
    
    public GetUserProfileQueryHandler(IUserProfileRepository userProfileRepository)
    {
        _userProfileRepository = userProfileRepository;
    }
    public async Task<UserProfileModel> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
    {
        if (request == null || request.Id == Guid.Empty)
        {
            throw new ArgumentNullException();
        }
        
        return await _userProfileRepository.GetSingleUserProfile(request.Id, cancellationToken);
    }
}