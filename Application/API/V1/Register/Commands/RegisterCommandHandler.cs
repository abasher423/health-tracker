using Application.Abstractions.Messaging;
using Application.Abstractions.Services;
using Application.API.V1.Register.Models;
using AutoMapper;

namespace Application.API.V1.Register.Commands;

public class RegisterCommandHandler : ICommandHandler<RegisterCommand, RegisterModel>
{
    private readonly IMapper _mapper;
    private readonly IAccountService _accountService;

    public RegisterCommandHandler(IAccountService accountService, IMapper mapper)
    {
        _accountService = accountService;
        _mapper = mapper;
    }

    public async Task<RegisterModel> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            return null;
        }

        return await _accountService.Register(_mapper.Map<RegisterRequest>(request), cancellationToken);
    }
}