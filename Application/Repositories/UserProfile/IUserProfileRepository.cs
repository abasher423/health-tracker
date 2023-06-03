using Application.API.V1.UserProfile.Commands.Create;
using Application.API.V1.UserProfile.Commands.Update;
using Application.API.V1.UserProfile.Models;

namespace Application.Repositories.UserProfile;

public interface IUserProfileRepository
{
    Task<IEnumerable<UserProfileModel>> GetAllUserProfiles(CancellationToken cancellationToken);
    Task<UserProfileModel> GetSingleUserProfile(Guid id, CancellationToken cancellationToken);
    Task<CreateUserProfileModel> CreateUserProfile(CreateUserProfileCommand userProfile, CancellationToken cancellationToken);
    Task<UpdateUserProfileModel> UpdateUserProfile(UpdateUserProfileCommand userProfile, CancellationToken cancellationToken);
    Task<bool> DeleteUserProfile(Guid id, CancellationToken cancellationToken);
}