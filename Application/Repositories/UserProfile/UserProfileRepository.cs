using Application.API.V1.UserProfile.Commands.Create;
using Application.API.V1.UserProfile.Commands.Update;
using Application.API.V1.UserProfile.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations.Context;

namespace Application.Repositories.UserProfile;

public class UserProfileRepository : IUserProfileRepository
{
    private readonly HealthTrackerDbContext _context;
    private readonly IMapper _mapper;

    public UserProfileRepository(HealthTrackerDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserProfileModel> GetSingleUserProfile(Guid id, CancellationToken cancellationToken)
    {
        var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return _mapper.Map<UserProfileModel>(userProfile);
    }

    public async Task<IEnumerable<UserProfileModel>> GetAllUserProfiles(CancellationToken cancellationToken)
    {
        var userProfiles = await _context.UserProfiles.ToListAsync(cancellationToken);
        return _mapper.Map<IEnumerable<UserProfileModel>>(userProfiles);
    }

    public async Task<CreateUserProfileModel> CreateUserProfile(CreateUserProfileCommand userProfile, CancellationToken cancellationToken)
    {
        var userProfileToBeAdded = new Domain.Entities.UserProfile()
        {
            Id = new Guid(),
            UserId = userProfile.UserId,
            Age = userProfile.Age,
            Gender = userProfile.Gender,
            Height = userProfile.Height,
            Weight = userProfile.Weight
        };
        
        await _context.UserProfiles.AddAsync(userProfileToBeAdded, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        
        return _mapper.Map<CreateUserProfileModel>(userProfileToBeAdded);
    }

    public async Task<UpdateUserProfileModel> UpdateUserProfile(UpdateUserProfileCommand userProfile, CancellationToken cancellationToken)
    {
        var userProfileToUpdate = _context.UserProfiles.FirstOrDefault(x => x.Id == userProfile.Id);

        if (userProfileToUpdate == null)
        {
            return null;
        }
        
        userProfileToUpdate.Gender = userProfile.Gender != null ? userProfile.Gender : userProfileToUpdate.Gender;
        userProfileToUpdate.Age = userProfile.Age != null ? userProfile.Age : userProfileToUpdate.Age;
        userProfileToUpdate.Height = userProfile.Height != null ? userProfile.Height : userProfileToUpdate.Height;
        userProfileToUpdate.Weight = userProfile.Weight != null ? userProfile.Weight : userProfileToUpdate.Weight;

        _context.Entry(userProfileToUpdate).State = EntityState.Modified;
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<UpdateUserProfileModel>(userProfileToUpdate);
    }

    public async Task<bool> DeleteUserProfile(Guid id, CancellationToken cancellationToken)
    {
        var userProfileToDelete = _context.UserProfiles.FirstOrDefault(x => x.Id == id);

        if (userProfileToDelete == null)
        {
            return false;
        }

        _context.UserProfiles.Remove(userProfileToDelete);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}