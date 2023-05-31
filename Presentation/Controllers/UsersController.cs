using Application.API.V1.User.Commands.Create;
using Application.API.V1.User.Models;
using HealthTracker.DTOs.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HealthTracker.Controllers;

[Route("[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create")]
    public async Task<ActionResult<CreateUserDto>> CreateUser([FromBody] CreateUserModel user)
    {
        var command = new CreateUserCommand(user);

        var result = await _mediator.Send(command);

        if (result == null)
        {
            return BadRequest();
        }

        return Ok(result);
        //return CreatedAtAction("GetUser", new { Id = result. }, result);
    }
}