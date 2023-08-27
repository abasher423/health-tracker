using Application.Abstractions.Messaging;
using Application.Abstractions.Services;
using Application.API.V1.User.Models;
using AutoMapper;

namespace Application.API.V1.User.Commands.Update;

public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand, UserModel>
{
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public UpdateUserCommandHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    
    public async Task<UserModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException();
        }

        var mappedUser = _mapper.Map<UserModel>(request);
        return await _userService.UpdateUser(mappedUser, cancellationToken);
    }
}