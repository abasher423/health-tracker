using Application.Abstractions.Services;
using Application.API.V1.User.Models;
using MediatR;

namespace Application.API.V1.User.Queries;

public class ListUsersQueryHandler : IRequestHandler<ListUsersQuery, IEnumerable<UserModel>>
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