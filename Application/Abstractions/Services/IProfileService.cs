
using Application.API.V1.UserProfile.Models;

namespace Application.Abstractions.Services;

public interface IProfileService
{
    Task<IEnumerable<UserProfileModel>> GetProfiles(CancellationToken cancellationToken);
    Task<UserProfileModel> GetProfile(Guid id, CancellationToken cancellationToken);
    Task<UserProfileModel> CreateProfile(UserProfileModel profile, CancellationToken cancellationToken);
    Task<UserProfileModel> UpdateProfile(UserProfileModel profile, CancellationToken cancellationToken);
    Task<bool> DeleteProfile(Guid id, CancellationToken cancellationToken);
}