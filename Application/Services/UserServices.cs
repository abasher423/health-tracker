using Application.Abstractions.Services;
using Application.API.V1.User.Models;
using AutoMapper;
using Domain.Entities;
using Persistence.Repositories.Users;

namespace Application.Services;

public class UserServices : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserServices(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }


    public async Task<IEnumerable<UserModel>> GetAllUsers(CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetUsers(cancellationToken);
        return _mapper.Map<IEnumerable<UserModel>>(users);
    }

    public async Task<UserModel> GetSingleUser(Guid id, CancellationToken cancellationToken)
    {
        var user =  await _userRepository.GetSingleUser(id, cancellationToken);
        return _mapper.Map<UserModel>(user);
    }

    public async Task<UserModel> UpdateUser(UserModel user, CancellationToken cancellationToken)
    {
        var updatedUser = await _userRepository.UpdateUser(_mapper.Map<User>(user), cancellationToken);

        if (updatedUser == null)
            return null;

        return user;
    }

    public async Task<bool> DeleteUser(Guid id, CancellationToken cancellationToken)
    {
        return await _userRepository.DeleteUser(id, cancellationToken);
    }
}