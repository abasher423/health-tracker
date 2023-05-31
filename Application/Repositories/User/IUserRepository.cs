using Application.API.V1.User.Commands.Create;
using Application.API.V1.User.Models;

namespace Application.Repositories.User;

public interface IUserRepository
{
    Task<IEnumerable<UserModel>> GetUsers(CancellationToken cancellationToken);
    Task<UserModel> CreateUser(CreateUserCommand user, CancellationToken cancellationToken);
}