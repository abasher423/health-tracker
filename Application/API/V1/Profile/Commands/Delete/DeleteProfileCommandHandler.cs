using Application.Abstractions.Messaging;
using Application.Abstractions.Services;

namespace Application.API.V1.Profile.Commands.Delete;

public class DeleteProfileCommandHandler : ICommandHandler<DeleteProfileCommand, bool>
{
    private readonly IProfileService _profileService;

    public DeleteProfileCommandHandler(IProfileService profileService)
    {
        _profileService = profileService;
    }
    
    public async Task<bool> Handle(DeleteProfileCommand request, CancellationToken cancellationToken)
    {
        if (request == null || request.Id == Guid.Empty)
        {
            throw new ArgumentNullException();
        }
        
        return  await _profileService.DeleteProfile(request.Id, cancellationToken);
    }
}