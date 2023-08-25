using Domain.Entities;

namespace Persistence.Repositories.Users;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetUsers(CancellationToken cancellationToken);
    Task<User> GetSingleUser(Guid id, CancellationToken cancellationToken);
    Task<User>? GetByEmail(string email, CancellationToken cancellationToken);
    Task<User> GetByEmailToken(string token, CancellationToken cancellationToken);
    Task<bool> IsEmailUniqueAsync(string email, CancellationToken cancellationToken);
    Task<User> CreateUser(User user, CancellationToken cancellationToken);
    Task<User> UpdateUser(User user, CancellationToken cancellationToken);
    Task<bool> DeleteUser(Guid id, CancellationToken cancellationToken);
}