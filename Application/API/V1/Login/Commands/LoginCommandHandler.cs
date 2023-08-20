using Application.Abstractions;
using Application.Abstractions.Services;
using Application.API.V1.Login.Models;
using AutoMapper;
using MediatR;

namespace Application.API.V1.Login.Commands;

public sealed class LoginCommandHandler : IRequestHandler<LoginCommand, LoginModel>
{
    private readonly IAccountService _accountService;
    private readonly IMapper _mapper;

    public LoginCommandHandler( IAccountService accountService, IMapper mapper)
    {
        _accountService = accountService;
        _mapper = mapper;
    }

    public async Task<LoginModel> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            return null;
        }

        return await _accountService.Login(_mapper.Map<LoginRequest>(request), cancellationToken);
    }
}