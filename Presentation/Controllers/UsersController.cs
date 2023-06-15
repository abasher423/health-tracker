using Application.API.V1.Login.Commands;
using Application.API.V1.Login.Models;
using Application.API.V1.User.Commands.Create;
using Application.API.V1.User.Commands.Delete;
using Application.API.V1.User.Commands.Update;
using Application.API.V1.User.Models;
using Application.API.V1.User.Queries;
using HealthTracker.DTOs.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthTracker.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
    {
        var query = new ListUsersQuery();
        
        var result = await _mediator.Send(query);
        
        return Ok(result);
    }

    [Authorize] // require anyone that is hitting this endpoint to be authenticated using a jwt
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UserDto>> GetUser(Guid id)
    {
        var query = new GetUserQuery(id);
        
        var result = await _mediator.Send(query);

        if (result == null)
        {
            return NotFound("User does not exist for the given id");
        }
        
        return Ok(result);
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
        
        return CreatedAtAction("GetUser", new { Id = result.Id }, result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginUser([FromBody] LoginModel loginModel, CancellationToken cancellationToken)
    {
        var command = new LoginCommand(loginModel.Email);

        var tokenResult = await _mediator.Send(command, cancellationToken);

        if (tokenResult == null)
        {
            return NotFound();
        }

        return Ok(tokenResult);
    }

    [HttpPut("update/{id:guid}")]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserModel user, Guid id)
    {
        var command = new UpdateUserCommand(user, id);

        var result = await _mediator.Send(command);

        if (result == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("delete/{id:guid}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        var command = new DeleteUserCommand(id);

        var result = await _mediator.Send(command);

        if (!result)
        {
            return NoContent();
        }

        return Accepted();
    }
}