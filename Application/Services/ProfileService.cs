using Application.Abstractions;
using Application.API.V1.UserProfile.Models;
using AutoMapper;
using Domain.Entities;
using Persistence.Repositories.UserProfiles;

namespace Application.Services;

public class ProfileService : IProfileService
{
    private readonly IMapper _mapper;
    private readonly IUserProfileRepository _userProfileRepository;

    public ProfileService(IUserProfileRepository userProfileRepository, IMapper mapper)
    {
        _userProfileRepository = userProfileRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserProfileModel>> GetProfiles(CancellationToken cancellationToken)
    {
        var profiles = await _userProfileRepository.GetAllUserProfiles(cancellationToken);
        return _mapper.Map<IEnumerable<UserProfileModel>>(profiles);
    }

    public async Task<UserProfileModel> GetProfile(Guid id, CancellationToken cancellationToken)
    {
        var profile = await _userProfileRepository.GetSingleUserProfile(id, cancellationToken);

        // do we want to throw an exception?
        if (profile == null)
            return null; 
        
        return _mapper.Map<UserProfileModel>(profile);
    }

    public async Task<UserProfileModel> CreateProfile(UserProfileModel profile, CancellationToken cancellationToken)
    {
        var userProfile = _mapper.Map<UserProfile>(profile);
        var createdProfile = await _userProfileRepository.CreateUserProfile(userProfile, cancellationToken);
        
        // do we want to throw an exception?
        if (createdProfile == null)
            return null;

        return profile;
    }

    public async Task<UserProfileModel> UpdateProfile(UserProfileModel profile, CancellationToken cancellationToken)
    {
        var userProfile = _mapper.Map<UserProfile>(profile);
        var updatedProfile = await _userProfileRepository.UpdateUserProfile(userProfile, cancellationToken);

        if (updatedProfile == null)
            return null;

        return profile;
    }

    public async Task<bool> DeleteProfile(Guid id, CancellationToken cancellationToken)
    {
        var isProfileDeleted = await _userProfileRepository.DeleteUserProfile(id, cancellationToken);
        return isProfileDeleted;
    }
}