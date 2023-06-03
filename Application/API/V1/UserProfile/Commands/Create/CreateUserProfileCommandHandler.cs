using Application.API.V1.UserProfile.Models;
using Application.Repositories.UserProfile;
using MediatR;

namespace Application.API.V1.UserProfile.Commands.Create;

public class CreateUserProfileCommandHandler : IRequestHandler<CreateUserProfileCommand, CreateUserProfileModel>
{
    // we will use a repository for data access so we can unit test better
    private readonly IUserProfileRepository _userProfileRepository;
    public CreateUserProfileCommandHandler(IUserProfileRepository userProfileRepository)
    {
        _userProfileRepository = userProfileRepository;
    }

    public async Task<CreateUserProfileModel> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException();
        }

        return await _userProfileRepository.CreateUserProfile(request, cancellationToken);
    }
}