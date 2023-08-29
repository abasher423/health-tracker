using Common.Exceptions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations.Context;

namespace Persistence.Repositories.UserProfiles;

public class UserProfileRepository : IUserProfileRepository
{
    private readonly HealthTrackerDbContext _context;

    public UserProfileRepository(HealthTrackerDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<UserProfile>> GetAllUserProfiles(CancellationToken cancellationToken)
    {
        var userProfiles = await _context.UserProfiles.ToListAsync(cancellationToken);
        return userProfiles;
    }
    
    public async Task<UserProfile> GetSingleUserProfile(Guid id, CancellationToken cancellationToken)
    {
        var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return userProfile;
    }


    public async Task<UserProfile> CreateUserProfile(UserProfile userProfile, CancellationToken cancellationToken)
    {
        var existingProfile = await _context.UserProfiles.FirstOrDefaultAsync(x => x.UserId == userProfile.UserId, cancellationToken);

        if (existingProfile != null)
        {
            throw new ProfileArgumentException("A profile with the provided user ID already exists.");
        }
        
        var userProfileToBeAdded = new UserProfile()
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

        return userProfileToBeAdded;
    }

    public async Task<UserProfile> UpdateUserProfile(UserProfile userProfile, CancellationToken cancellationToken)
    {
        var userProfileToUpdate = _context.UserProfiles.FirstOrDefault(x => x.Id == userProfile.Id);

        if (userProfileToUpdate == null)
            return null;

        userProfileToUpdate.Gender = userProfile.Gender != null ? userProfile.Gender : userProfileToUpdate.Gender;
        userProfileToUpdate.Age = userProfile.Age != 0 ? userProfile.Age : userProfileToUpdate.Age;
        userProfileToUpdate.Height = userProfile.Height != 0 ? userProfile.Height : userProfileToUpdate.Height;
        userProfileToUpdate.Weight = userProfile.Weight != 0 ? userProfile.Weight : userProfileToUpdate.Weight;

        _context.Entry(userProfileToUpdate).State = EntityState.Modified;
        await _context.SaveChangesAsync(cancellationToken);

        return userProfileToUpdate;
    }

    public async Task<bool> DeleteUserProfile(Guid id, CancellationToken cancellationToken)
    {
        var userProfileToDelete = _context.UserProfiles.FirstOrDefault(x => x.Id == id);

        if (userProfileToDelete == null)
            return false;

        _context.UserProfiles.Remove(userProfileToDelete);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}