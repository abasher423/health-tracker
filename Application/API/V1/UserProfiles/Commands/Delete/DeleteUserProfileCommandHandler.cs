using MediatR;

namespace Application.API.V1.UserProfiles.Commands.Delete;

public class DeleteUserProfileCommandHandler : IRequestHandler<DeleteUserProfileCommand, bool>
{
    private readonly IUserProfileRepository _userProfileRepository;

    public DeleteUserProfileCommandHandler(IUserProfileRepository userProfileRepository)
    {
        _userProfileRepository = userProfileRepository;
    }
    
    public async Task<bool> Handle(DeleteUserProfileCommand request, CancellationToken cancellationToken)
    {
        if (request == null || request.Id == Guid.Empty)
        {
            throw new ArgumentNullException();
        }
        
        return  await _userProfileRepository.DeleteUserProfile(request.Id, cancellationToken);
    }
}