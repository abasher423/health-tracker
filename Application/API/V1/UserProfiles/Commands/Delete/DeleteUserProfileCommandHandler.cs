using AutoMapper;
using MediatR;
using Persistence.Configurations.Context;

namespace Application.API.V1.UserProfiles.Commands.Delete;

public class DeleteUserProfileCommandHandler : IRequestHandler<DeleteUserProfileCommand, bool>
{
    private readonly HealthTrackerDbContext _context;
    private readonly IMapper _mapper;

    public DeleteUserProfileCommandHandler(HealthTrackerDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<bool> Handle(DeleteUserProfileCommand request, CancellationToken cancellationToken)
    {
        var userProfileToDelete = _context.UserProfiles.FirstOrDefault(x => x.Id == request.Id);

        if (userProfileToDelete == null)
        {
            return false;
        }

        _context.UserProfiles.Remove(userProfileToDelete);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}