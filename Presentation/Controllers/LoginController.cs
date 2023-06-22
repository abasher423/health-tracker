using Application.Abstractions;
using Application.API.V1.Login.Commands;
using Application.API.V1.Login.Models;
using Application.API.V1.Register.Commands;
using Application.API.V1.Register.Models;
using AutoMapper;
using HealthTracker.DTOs.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HealthTracker.Controllers;

[Route("api")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IAccountService _accountService;

    public LoginController(IAccountService accountService, IMediator mediator, IMapper mapper)
    {
        _accountService = accountService;
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<ActionResult<LoginDto>> Register([FromBody] RegisterRequest registerRequest, CancellationToken cancellationToken)
    {
        var command = new RegisterCommand(registerRequest);

        var result = await _mediator.Send(command, cancellationToken);

        if (result == null)
        {
            return BadRequest();
        }

        return _mapper.Map<LoginDto>(result);
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginDto>> Login([FromBody] LoginRequest loginRequest, CancellationToken cancellationToken)
    {
        var command = new LoginCommand(loginRequest.Email, loginRequest.Password);

        var result = await _mediator.Send(command, cancellationToken);

        if (result == null)
        {
            return Unauthorized();
        }

        return _mapper.Map<LoginDto>(result);
    }
}