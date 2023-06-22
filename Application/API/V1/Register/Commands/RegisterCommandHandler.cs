using Application.Abstractions;
using Application.API.V1.Register.Models;
using AutoMapper;
using MediatR;

namespace Application.API.V1.Register.Commands;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterModel>
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