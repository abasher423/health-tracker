using Application.Abstractions;
using Application.Abstractions.Services;
using Application.API.V1.Profile.Models;
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
        return _mapper.Map<UserProfileModel>(profile);
    }

    public async Task<UserProfileModel> CreateProfile(UserProfileModel profile, CancellationToken cancellationToken)
    {
        var userProfileToCreate = new UserProfile()
        {
            Id = Guid.NewGuid(),
            UserId = profile.UserId,
            Gender = profile.Gender,
            Age = profile.Age,
            Height = profile.Height,
            Weight = profile.Weight
        };
        
        var createdProfile = await _userProfileRepository.CreateUserProfile(userProfileToCreate, cancellationToken);

        return _mapper.Map<UserProfileModel>(createdProfile);
    }

    public async Task<UserProfileModel> UpdateProfile(UserProfileModel profile, CancellationToken cancellationToken)
    {
        var userProfileToUpdate = new UserProfile()
        {
            Id = profile.Id,
            UserId = profile.UserId,
            Gender = profile.Gender,
            Age = profile.Age,
            Height = profile.Height,
            Weight = profile.Weight
        };
        
        var updatedProfile = await _userProfileRepository.UpdateUserProfile(userProfileToUpdate, cancellationToken);

        return _mapper.Map<UserProfileModel>(updatedProfile);
    }

    public async Task<bool> DeleteProfile(Guid id, CancellationToken cancellationToken)
    {
        return await _userProfileRepository.DeleteUserProfile(id, cancellationToken);
    }
}