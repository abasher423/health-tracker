using Application.API.V1.UserProfile.Commands.Create;
using Application.API.V1.UserProfile.Commands.Delete;
using Application.API.V1.UserProfile.Commands.Update;
using Application.API.V1.UserProfile.Models;
using Application.API.V1.UserProfile.Queries;
using HealthTracker.DTOs.UserProfile;
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
        
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UserProfileDto>> GetUserProfile(Guid id)
    {
        var userProfile = new GetUserProfileQuery(id);
        
        var result = await _mediator.Send(userProfile);

        if (result == null)
        {
            return NotFound("User profile does not exist for the given id");
        }
        
        return Ok(result);
    }

    [HttpPost("create")]
    public async Task<ActionResult<UserProfileDto>> CreateUserProfile([FromBody] CreateUserProfileDto userProfile)
    {
        var command = new CreateUserProfileCommand()
        {
            UserId = userProfile.UserId,
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

    [HttpPut("update/{id:guid}")]
    public async Task<IActionResult> UpdateUserProfile([FromBody] UpdateUserProfileDto userProfile, Guid id)
    {
        var command = new UpdateUserProfileCommand()
        {
            Id = id,
            UserId = userProfile.UserId,
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

        if (result == false)
        {
            return NoContent();
        }
        
        return Accepted();
    }
}