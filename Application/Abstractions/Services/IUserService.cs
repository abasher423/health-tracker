using Application.API.V1.User.Models;

namespace Application.Abstractions.Services;

public interface IUserService
{
    Task<IEnumerable<UserModel>> GetAllUsers(CancellationToken cancellationToken);
    Task<UserModel> GetSingleUser(Guid id, CancellationToken cancellationToken);
}