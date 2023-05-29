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

    public async Task<UserProfileDto> GetSingleUserProfile(Guid id, CancellationToken cancellationToken)
    {
        var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return _mapper.Map<UserProfileDto>(userProfile);
    }

    public async Task<IEnumerable<UserProfileDto>> GetAllUserProfiles(CancellationToken cancellationToken)
    {
        var userProfiles = await _context.UserProfiles.ToListAsync(cancellationToken);
        return _mapper.Map<IEnumerable<UserProfileDto>>(userProfiles);
    }

    public async Task<CreateUserProfileDto> CreateUserProfile(CreateUserProfileCommand userProfile, CancellationToken cancellationToken)
    {
        var userProfileToBeAdded = new Domain.Entities.UserProfile()
        {
            Id = new Guid(),
            Age = userProfile.Age,
            Gender = userProfile.Gender,
            Height = userProfile.Height,
            Weight = userProfile.Weight
        };
        
        await _context.UserProfiles.AddAsync(userProfileToBeAdded, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        
        return _mapper.Map<CreateUserProfileDto>(userProfile);
    }

    public async Task<UpdateUserProfileDto> UpdateUserProfile(UpdateUserProfileCommand userProfile, CancellationToken cancellationToken)
    {
        var userProfileToUpdate = _context.UserProfiles.FirstOrDefault(x => x.Id == userProfile.Id);

        if (userProfileToUpdate == null)
        {
            return null;
        }

        userProfileToUpdate.Gender = userProfile.Gender;
        userProfileToUpdate.Age = userProfile.Age;
        userProfileToUpdate.Height = userProfile.Height;
        userProfileToUpdate.Weight = userProfile.Weight;

        _context.Entry(userProfileToUpdate).State = EntityState.Modified;
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<UpdateUserProfileDto>(userProfileToUpdate);
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