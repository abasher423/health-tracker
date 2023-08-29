using Application.API.V1.Profile.Commands.Create;
using Application.API.V1.Profile.Commands.Delete;
using Application.API.V1.Profile.Commands.Update;
using Application.API.V1.Profile.Models;
using Application.API.V1.Profile.Queries;
using HealthTracker.DTOs.UserProfile;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HealthTracker.Controllers;

[Route("api/profiles")]
[ApiController]
public class ProfilesController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public ProfilesController(IMediator mediator)
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
    public async Task<ActionResult<CreateUserProfileDto>> CreateUserProfile([FromBody] CreateUserProfileModel request)
    {
        var validator = new CreateProfileCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        
        var command = new CreateProfileCommand(request);

        var result = await _mediator.Send(command);

        if (result == null)
        {
            return BadRequest();
        }

        return CreatedAtAction("GetUserProfile", new { Id = result.Id }, result);
    }

    [HttpPut("update/{id:guid}")]
    public async Task<IActionResult> UpdateUserProfile([FromBody] UpdateUserProfileModel userProfile, Guid id)
    {
        var command = new ProfileCommand(userProfile, id);

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
        var userProfile = new DeleteProfileCommand(id);
        
        var result = await _mediator.Send(userProfile);

        if (!result)
        {
            return NoContent();
        }
        
        return Accepted();
    }
}