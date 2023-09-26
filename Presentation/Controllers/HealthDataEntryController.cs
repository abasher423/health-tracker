using Application.Abstractions.Services;
using Application.API.V1.HealthDataEntry.Commands.Create;
using Application.API.V1.HealthDataEntry.Commands.Delete;
using Application.API.V1.HealthDataEntry.Commands.Update;
using Application.API.V1.HealthDataEntry.Models;
using Application.API.V1.HealthDataEntry.Queries;
using HealthTracker.DTOs.HealthDataEntry;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HealthTracker.Controllers;

[Route("api/health-data-entries")]
[ApiController]
public class HealthDataEntryController : ControllerBase
{
    private readonly IHealthDataEntryService _healthDataEntryService;
    private readonly IMediator _mediator;

    public HealthDataEntryController(IHealthDataEntryService healthDataEntryService, IMediator mediator)
    {
        _healthDataEntryService = healthDataEntryService;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<HealthDataEntryDto>>> ListHealthDataEntries()
    {
        var query = new ListHealthDataEntriesQuery();

        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<HealthDataEntryDto>> GetHealthDataEntry(Guid id)
    {
        var query = new GetHealthDataEntryQuery(id);

        var result = await _mediator.Send(query);

        if (result == null)
        {
            return BadRequest("Health data entry does not exist for the given id");
        }

        return Ok(result);
    }

    // check return type
    [HttpPost("/create")]
    public async Task<IActionResult> CreateHealthDataEntry([FromBody] CreateHealthDataEntryModel request)
    {
        var validator = new CreateHealthDataEntryValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        var command = new CreateHealthDataEntryCommand(request);

        var result = await _mediator.Send(command);

        if (result == null)
        {
            return BadRequest();
        }
        
        return CreatedAtAction("GetHealthDataEntry", new { Id = result.Id }, result);
    }

    [HttpPut("update/{id:guid}")]
    public async Task<IActionResult> UpdateHealthDataEntry([FromBody] UpdateHealthDataEntryModel request, Guid id)
    {
        var command = new UpdateHealthDataEntryCommand(request, id);

        var result = _mediator.Send(command);

        if (result == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("delete/{id:guid}")]
    public async Task<IActionResult> DeleteHealthDataEntry(Guid id)
    {
        var command = new DeleteHealthDataEntryCommand(id);

        var result = await _mediator.Send(command);

        if (!result)
        {
            return NoContent();
        }

        return Accepted();
    }
}