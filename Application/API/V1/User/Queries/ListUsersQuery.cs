using Application.API.V1.User.Models;
using MediatR;

namespace Application.API.V1.User.Queries;

public class ListUsersQuery : IRequest<IEnumerable<UserModel>>
{
}