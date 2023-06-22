using Application.API.V1.User.Models;

namespace Application.Abstractions.Services;

public interface IUserService
{
    Task<IEnumerable<UserModel>> GetAllUsers(CancellationToken cancellationToken);
    Task<UserModel> GetSingleUser (Guid id, CancellationToken cancellationToken);
    Task<UserModel> UpdateUser (UserModel user, CancellationToken cancellationToken);
    Task<bool> DeleteUser(Guid id, CancellationToken cancellationToken);
}