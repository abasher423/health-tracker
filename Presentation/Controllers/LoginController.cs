using Application.Abstractions;
using Application.Abstractions.Services;
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
    public async Task<ActionResult<RegisterDto>> Register([FromBody] RegisterRequest request, CancellationToken cancellationToken)
    {
        var validator = new RegisterCommandValidator();
        var validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        
        var command = new RegisterCommand(request);

        var result = await _mediator.Send(command, cancellationToken);

        if (result == null)
        {
            return BadRequest();
        }

        return _mapper.Map<RegisterDto>(result);
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