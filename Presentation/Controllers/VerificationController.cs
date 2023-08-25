using Application.API.V1.Verification.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HealthTracker.Controllers;

[Route("api/verify")]
[ApiController]
public class VerificationController : ControllerBase
{
    private readonly IMediator _mediator;

    public VerificationController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet("{token}")]
    public async Task<IActionResult> VerifyEmail(string token)
    {
        var command = new VerifyEmailCommand(token);

        var result = await _mediator.Send(command);

        if (result)
        {
            return Ok("Email successfully verified");
        }
        else
        {
            return BadRequest("Email verification failed");
        }
    }
}