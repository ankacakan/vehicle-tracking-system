using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleTracking.Application.Features.DriverFeatures.Queries;
using VehicleTracking.Domain.Dtos;
using VehicleTracking.Presentation.Abstraction;

namespace VehicleTracking.Presentation.Controllers;

public class DriverController(IMediator mediator) : ApiController(mediator)
{
    [HttpPost("[action]")]
    public async Task<ActionResult<IEnumerable<DriverDto>>> Get(
    [FromQuery] int? id,
         [FromQuery] int customerId)
    {
        var result = await _mediator.Send(new GetDriverQuery(id, customerId));
        if (id.HasValue && !result.Any())
            return NotFound();
        return Ok(result);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update(
        [FromBody] UpdateDriverCommand cmd,
        CancellationToken ct)
    {
        await _mediator.Send(cmd, ct);
        return NoContent();
    }
}
