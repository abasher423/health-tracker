using Application.API.V1.UserProfiles.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations.Context;

namespace Application.API.V1.UserProfiles.Queries;

public class ListUserProfilesQueryHandler : IRequestHandler<ListUserProfilesQuery, IEnumerable<UserProfileDto>>
{
    private readonly HealthTrackerDbContext _context;
    private readonly IMapper _mapper;

    public ListUserProfilesQueryHandler(HealthTrackerDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<UserProfileDto>> Handle(ListUserProfilesQuery request, CancellationToken cancellationToken)
    {
        var userProfiles = await _context.UserProfiles.ToListAsync(cancellationToken);
        return _mapper.Map<IEnumerable<UserProfileDto>>(userProfiles);
    }
}