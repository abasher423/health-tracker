using Application.API.V1.UserProfiles.Models;
using Application.Repositories.UserProfile;
using MediatR;

namespace Application.API.V1.UserProfiles.Commands.Create;

public class CreateUserProfileCommandHandler : IRequestHandler<CreateUserProfileCommand, CreateUserProfileDto>
{
    // we will use a repository for data access so we can unit test better
    private readonly IUserProfileRepository _userProfileRepository;
    public CreateUserProfileCommandHandler(IUserProfileRepository userProfileRepository)
    {
        _userProfileRepository = userProfileRepository;
    }

    public async Task<CreateUserProfileDto> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException();
        }

        return await _userProfileRepository.CreateUserProfile(request, cancellationToken);
    }
}