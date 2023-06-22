using Application.API.V1.User.Models;
using MediatR;

namespace Application.API.V1.User.Queries;

public class ListUsersQueryHandler : IRequestHandler<ListUsersQuery, IEnumerable<UserModel>>
{
    private readonly IUserRepository _userRepository;

    public ListUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<IEnumerable<UserModel>> Handle(ListUsersQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetUsers(cancellationToken);
    }
}