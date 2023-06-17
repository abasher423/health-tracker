using Application.API.V1.User.Commands.Update;
using Application.API.V1.User.Models;

namespace Application.Repositories.User;

public interface IUserRepository
{
    Task<IEnumerable<UserModel>> GetUsers(CancellationToken cancellationToken);
    Task<UserModel> GetSingleUser(Guid id, CancellationToken cancellationToken);
    Task<UserModel> GetByEmail(string email, CancellationToken cancellationToken);
    Task<UserModel> CreateUser(UserModel user, CancellationToken cancellationToken);
    Task<UpdateUserModel> UpdateUser(UpdateUserCommand user, CancellationToken cancellationToken);
    Task<bool> DeleteUser(Guid id, CancellationToken cancellationToken);
}