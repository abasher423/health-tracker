using Application.API.V1.UserProfiles.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations.Context;

namespace Application.API.V1.UserProfiles.Queries;

public class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQuery, UserProfileDto>
{
    private readonly HealthTrackerDbContext _context;
    private readonly IMapper _mapper;
    
    public GetUserProfileQueryHandler(HealthTrackerDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<UserProfileDto> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
    {
        var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        return _mapper.Map<UserProfileDto>(userProfile);
    }
}