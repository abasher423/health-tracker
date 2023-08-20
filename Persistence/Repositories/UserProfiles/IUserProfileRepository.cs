using Domain.Entities;

namespace Persistence.Repositories.UserProfiles;

public interface IUserProfileRepository
{
    Task<IEnumerable<UserProfile>> GetAllUserProfiles(CancellationToken cancellationToken);
    Task<UserProfile> GetSingleUserProfile(Guid id, CancellationToken cancellationToken);
    Task<UserProfile> CreateUserProfile(UserProfile userProfile, CancellationToken cancellationToken);
    Task<UserProfile> UpdateUserProfile(UserProfile userProfile, CancellationToken cancellationToken);
    Task<bool> DeleteUserProfile(Guid id, CancellationToken cancellationToken);
}