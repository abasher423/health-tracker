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

        if (userProfile == null)
        {
            throw new ProfileArgumentException("Please provide a valid user profile ID");
        }
        
        return userProfile;
    }


    public async Task<UserProfile> CreateUserProfile(UserProfile userProfile, CancellationToken cancellationToken)
    {
        await CheckUserExists(userProfile.UserId, cancellationToken);
        await CheckProfileExists(userProfile.UserId, cancellationToken);
        
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
        {
            throw new ProfileArgumentException("The user profile to update was not found.");
        }

        if (!string.IsNullOrEmpty(userProfile.Gender.ToString()))
        {
            userProfileToUpdate.Gender = userProfile.Gender;
        }

        if (!string.IsNullOrEmpty(userProfile.Age.ToString()) || userProfile.Age > 0)
        {
            userProfileToUpdate.Age = userProfile.Age;
        }

        if (!string.IsNullOrEmpty(userProfile.Height.ToString()) || userProfile.Height > 0)
        {
            userProfileToUpdate.Height = userProfile.Height;
        }

        if (!string.IsNullOrEmpty(userProfile.Weight.ToString()) || userProfile.Weight > 0)
        {
            userProfileToUpdate.Weight = userProfile.Weight;
        }

        _context.Entry(userProfileToUpdate).State = EntityState.Modified;
        await _context.SaveChangesAsync(cancellationToken);

        return userProfileToUpdate;
    }

    public async Task<bool> DeleteUserProfile(Guid id, CancellationToken cancellationToken)
    {
        var userProfileToDelete = _context.UserProfiles.FirstOrDefault(x => x.Id == id);

        if (userProfileToDelete == null)
        {
            throw new ProfileArgumentException("The user profile to delete was not found.");
        }

        _context.UserProfiles.Remove(userProfileToDelete);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    private async Task CheckProfileExists(Guid id, CancellationToken cancellationToken)
    {
        var existingProfile = await _context.UserProfiles.FirstOrDefaultAsync(x => x.UserId == id, cancellationToken);

        if (existingProfile != null)
        {
            throw new ProfileArgumentException("A profile with the provided user ID already exists.");
        }
    }
    
    private async Task CheckUserExists(Guid userId, CancellationToken cancellationToken)
    {
        var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);

        if (existingUser == null)
        {
            throw new ProfileArgumentException("Please provide a valid user ID");
        }
    }
}