using Application.Abstractions.Services;
using Application.API.V1.User.Models;
using MediatR;

namespace Application.API.V1.User.Queries;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserModel>
{
    private readonly IUserService _userService;

    public GetUserQueryHandler(IUserService userService)
    {
        _userService = userService;
    }
    public async Task<UserModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        if (request == null || request.Id == Guid.Empty)
        {
            return null;
        }

        return await _userService.GetSingleUser(request.Id, cancellationToken);
    }
}