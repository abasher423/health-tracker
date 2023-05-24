using Application.API.V1.UserProfiles.Commands.Create;
using Application.API.V1.UserProfiles.Models;

namespace Application.API.V1.UserProfiles;

public interface IUserProfileRepository
{
    Task<IEnumerable<UserProfileDto>> GetAllUserProfiles(CancellationToken cancellationToken);
    Task<CreateUserProfileDto> CreateUserProfile(CreateUserProfileCommand userProfile, CancellationToken cancellationToken);
}