using Application.Abstractions.Messaging;
using Application.API.V1.User.Models;

namespace Application.API.V1.User.Queries;

public class ListUsersQuery : IQuery<IEnumerable<UserModel>>
{
}