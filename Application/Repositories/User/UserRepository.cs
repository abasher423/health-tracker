using Application.API.V1.User.Commands.Create;
using Application.API.V1.User.Commands.Update;
using Application.API.V1.User.Models;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations.Context;

namespace Application.Repositories.User;

public class UserRepository : IUserRepository
{
    private readonly HealthTrackerDbContext _context;
    private readonly IMapper _mapper;

    public UserRepository(HealthTrackerDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserModel>> GetUsers(CancellationToken cancellationToken)
    {
        var users = await _context.Users.ToListAsync(cancellationToken);
        return _mapper.Map<IEnumerable<UserModel>>(users);
    }

    public async Task<UserModel> GetSingleUser(Guid id, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return _mapper.Map<UserModel>(user);
    }

    public async Task<UserModel> CreateUser(CreateUserCommand user, CancellationToken cancellationToken)
    {
        var userToBeAdded = new Domain.Entities.User()
        {
            Id = Guid.NewGuid(),
            Email = user.Email,
            Password = user.Password,
            FirstName = user.FirstName,
            LastName = user.LastName
        };

        await _context.Users.AddAsync(userToBeAdded, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<UserModel>(userToBeAdded);
    }

    public async Task<UpdateUserModel> UpdateUser(UpdateUserCommand user, CancellationToken cancellationToken)
    {
        // fetch user to be updated
        var userToUpdate = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id, cancellationToken);

        if (userToUpdate == null)
        {
            return null;
        }

        userToUpdate.Email = user.Email ?? userToUpdate.Email;
        userToUpdate.Password = user.Password ?? userToUpdate.Password;
        userToUpdate.FirstName = user.FirstName ?? userToUpdate.FirstName;
        userToUpdate.LastName = user.LastName ?? userToUpdate.LastName;
        
        _context.Entry(userToUpdate).State = EntityState.Modified;
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<UpdateUserModel>(userToUpdate);
    }
}