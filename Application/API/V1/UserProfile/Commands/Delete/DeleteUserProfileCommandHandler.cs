using Application.Abstractions;
using Application.Abstractions.Services;
using MediatR;

namespace Application.API.V1.UserProfile.Commands.Delete;

public class DeleteUserProfileCommandHandler : IRequestHandler<DeleteUserProfileCommand, bool>
{
    private readonly IProfileService _profileService;

    public DeleteUserProfileCommandHandler(IProfileService profileService)
    {
        _profileService = profileService;
    }
    
    public async Task<bool> Handle(DeleteUserProfileCommand request, CancellationToken cancellationToken)
    {
        if (request == null || request.Id == Guid.Empty)
        {
            throw new ArgumentNullException();
        }
        
        return  await _profileService.DeleteProfile(request.Id, cancellationToken);
    }
}