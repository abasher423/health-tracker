using Application.Abstractions.Messaging;
using Application.Abstractions.Services;

namespace Application.API.V1.UserProfile.Commands.Delete;

public class DeleteUserProfileCommandHandler : ICommandHandler<DeleteUserProfileCommand, bool>
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