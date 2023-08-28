using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations.Context;

namespace Persistence.Repositories.Users;

public class UserRepository : IUserRepository
{
    private readonly HealthTrackerDbContext _context;

    public UserRepository(HealthTrackerDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetUsers(CancellationToken cancellationToken)
    {
        var users = await _context.Users.ToListAsync(cancellationToken);
        return users;
    }

    public async Task<User> GetSingleUser(Guid id, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return user;
    }

    public async Task<User>? GetByEmail(string email, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
        return user;
    }

    public async Task<User> GetByEmailToken(string token, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.EmailVerificationToken == token, cancellationToken);
        return user;
    }

    public async Task<bool> IsEmailUniqueAsync(string email, CancellationToken cancellationToken)
    {
        if (await GetByEmail(email, cancellationToken) != null)
        {
            return false;
        }

        return true;
    }

    public async Task<User> CreateUser(User user, CancellationToken cancellationToken)
    {
        var userToBeAdded = new User()
        {
            Id = Guid.NewGuid(),
            Email = user.Email,
            EmailConfirmed = user.EmailConfirmed,
            EmailVerificationToken = user.EmailVerificationToken,
            EmailVerificationTokenExpiration = user.EmailVerificationTokenExpiration,
            EmailTokenStatus = user.EmailTokenStatus,
            HashedPassword = user.HashedPassword,
            FirstName = user.FirstName,
            LastName = user.LastName
        };

        await _context.Users.AddAsync(userToBeAdded, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return userToBeAdded;
    }

    public async Task<User> UpdateUser(User user, CancellationToken cancellationToken)
    {
        // fetch user to be updated
        var userToUpdate = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id, cancellationToken);

        if (userToUpdate == null)
        {
            return null;
        }

        if (!string.IsNullOrEmpty(user.Email))
        {
            userToUpdate.Email = user.Email;
        }

        if (!string.IsNullOrEmpty(user.HashedPassword))
        {
            userToUpdate.HashedPassword = user.HashedPassword;
        }

        if (!string.IsNullOrEmpty(user.FirstName))
        {
            userToUpdate.FirstName = user.FirstName;
        }

        if (!string.IsNullOrEmpty(user.LastName))
        {
            userToUpdate.LastName = user.LastName;
        }

        _context.Entry(userToUpdate).State = EntityState.Modified;
        await _context.SaveChangesAsync(cancellationToken);

        return userToUpdate;
    }

    public async Task<bool> DeleteUser(Guid id, CancellationToken cancellationToken)
    {
        var userToDelete = await _context.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (userToDelete == null)
        {
            return false;
        }

        _context.Users.Remove(userToDelete);
        await _context.SaveChangesAsync(cancellationToken);
        
        return true;
    }
}