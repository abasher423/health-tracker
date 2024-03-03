using Application.API.V1.HealthDataEntry.Models;
using Application.API.V1.HealthMetric.Commands.Create;
using Application.API.V1.HealthMetric.Commands.Delete;
using Application.API.V1.HealthMetric.Commands.Update;
using Application.API.V1.HealthMetric.Models;
using Application.API.V1.HealthMetric.Queries;
using HealthTracker.DTOs.HealthMetric;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HealthTracker.Controllers;

[Route("api/health-metric")]
[ApiController]
public class HealthMetricController : ControllerBase
{
    private readonly IMediator _mediator;

    public HealthMetricController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<HealthMetricDto>>> ListHealthMetrics()
    {
        var query = new ListHealthMetricsQuery();

        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<HealthMetricDto>> GetHealthMetric(Guid id)
    {
        var query = new GetHealthMetricQuery(id);

        var result = await _mediator.Send(query);

        if (result == null)
        {
            return BadRequest("Health metric does not exist for the given id");
        }

        return Ok(result);
    }

    [HttpPost("/create")]
    public async Task<IActionResult> CreateHealthMetric([FromBody] HealthMetricModel request)
    {
        var validator = new CreateHealthMetricCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        
        var command = new CreateHealthMetricCommand(request.Id, request.Type, request.UnitOfMeasure);

        var result = await _mediator.Send(command);

        if (result == null)
        {
            return BadRequest();
        }
        
        return CreatedAtAction("GetHealthMetric", new { Id = result.Id }, result);
    }

    [HttpPut("update/{id:guid}")]
    public async Task<IActionResult> UpdateHealthMetric([FromBody] HealthMetricModel request, Guid id)
    {
        var validator = new UpdateHealthMetricCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        var command = new UpdateHealthMetricCommand(request.Id, request.Type, request.UnitOfMeasure);

        var result = await _mediator.Send(command);

        if (result == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("/delete/{id:guid}")]
    public async Task<IActionResult> DeleteHealthMetric(Guid id)
    {
        var command = new DeleteHealthMetricCommand(id);

        var result = await _mediator.Send(command);

        if (!result)
        {
            return NoContent();
        }

        return Accepted();
    }
}