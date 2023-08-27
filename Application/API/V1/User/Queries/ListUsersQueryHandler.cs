using Application.Abstractions.Messaging;
using Application.Abstractions.Services;
using Application.API.V1.User.Models;

namespace Application.API.V1.User.Queries;

public class ListUsersQueryHandler : IQueryHandler<ListUsersQuery, IEnumerable<UserModel>>
{
    private readonly IUserService _userService;

    public ListUsersQueryHandler(IUserService userService)
    {
        _userService = userService;
    }
    public async Task<IEnumerable<UserModel>> Handle(ListUsersQuery request, CancellationToken cancellationToken)
    {
        return await _userService.GetAllUsers(cancellationToken);
    }
}