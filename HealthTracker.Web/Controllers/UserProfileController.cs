using Application.API.V1.UserProfiles.Commands.Create;
using Application.API.V1.UserProfiles.Commands.Delete;
using Application.API.V1.UserProfiles.Commands.Update;
using Application.API.V1.UserProfiles.Models;
using Application.API.V1.UserProfiles.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HealthTracker.Controllers;
[Route("api/userProfile")]
[ApiController]
public class UserProfileController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public UserProfileController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserProfileDto>>> ListUserProfiles()
    {
        var userProfiles = new ListUserProfilesQuery();
        
        var result = await _mediator.Send(userProfiles);

        if (result == null)
        {
            return null;
        }
        
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UserProfileDto>> GetUserProfile(Guid id)
    {
        var userProfile = new GetUserProfileQuery(id);
        var result = await _mediator.Send(userProfile);
        return Ok(result);
    }

    [HttpPost("create")]
    public async Task<ActionResult<UserProfileDto>> CreateUserProfile([FromBody] CreateUserProfileDto userProfile)
    {
        var command = new CreateUserProfileCommand()
        {
            Id = userProfile.Id,
            Age = userProfile.Age,
            Gender = userProfile.Gender,
            Height = userProfile.Height,
            Weight = userProfile.Weight
        };

        var result = await _mediator.Send(command);

        if (result == null)
        {
            return BadRequest();
        }

        return CreatedAtAction("GetUserProfile", new { Id = result.Id }, result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateUserProfile([FromBody] UpdateUserProfileDto userProfile)
    {
        var command = new UpdateUserProfileCommand()
        {
            Id = userProfile.Id,
            Age = userProfile.Age,
            Gender = userProfile.Gender,
            Height = userProfile.Height,
            Weight = userProfile.Weight
        };

        var result = await _mediator.Send(command);

        if (result == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("delete/{id:guid}")]
    public async Task<IActionResult> DeleteUserProfile(Guid id)
    {
        var userProfile = new DeleteUserProfileCommand(id);
        var result = await _mediator.Send(userProfile);
        return NoContent();
    }
}