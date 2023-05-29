using Application.API.V1.UserProfile.Commands.Create;
using Application.API.V1.UserProfile.Commands.Update;
using Application.API.V1.UserProfile.Models;

namespace Application.Repositories.UserProfile;

public interface IUserProfileRepository
{
    Task<IEnumerable<UserProfileDto>> GetAllUserProfiles(CancellationToken cancellationToken);
    Task<UserProfileDto> GetSingleUserProfile(Guid id, CancellationToken cancellationToken);
    Task<CreateUserProfileDto> CreateUserProfile(CreateUserProfileCommand userProfile, CancellationToken cancellationToken);
    Task<UpdateUserProfileDto> UpdateUserProfile(UpdateUserProfileCommand userProfile, CancellationToken cancellationToken);
    Task<bool> DeleteUserProfile(Guid id, CancellationToken cancellationToken);
}