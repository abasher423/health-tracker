using Application.API.V1.User.Models;
using MediatR;

namespace Application.API.V1.User.Queries;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserModel>
{
    private readonly IUserRepository _userRepository;

    public GetUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<UserModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        if (request == null || request.Id == Guid.Empty)
        {
            return null;
        }

        return await _userRepository.GetSingleUser(request.Id, cancellationToken);
    }
}