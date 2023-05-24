using Application.API.V1.UserProfiles.Commands.Create;
using Application.API.V1.UserProfiles.Models;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations.Context;

namespace Application.API.V1.UserProfiles;

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
        var userProfileToBeAdded = new UserProfile()
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
}