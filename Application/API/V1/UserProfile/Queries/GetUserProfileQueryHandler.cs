using Application.Abstractions;
using Application.Abstractions.Services;
using Application.API.V1.UserProfile.Models;
using MediatR;

namespace Application.API.V1.UserProfile.Queries;

public class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQuery, UserProfileModel>
{
    private readonly IProfileService _profileService;
    
    public GetUserProfileQueryHandler(IProfileService profileService)
    {
        _profileService = profileService;
    }
    public async Task<UserProfileModel> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
    {
        if (request == null || request.Id == Guid.Empty)
        {
            throw new ArgumentNullException();
        }
        
        return await _profileService.GetProfile(request.Id, cancellationToken);
    }
}