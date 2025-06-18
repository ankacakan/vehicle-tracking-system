using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleTracking.Application.Features.VehicleFeatures.Commands.UpdateVehicle;
using VehicleTracking.Application.Features.VehicleFeatures.Queries;
using VehicleTracking.Domain.Dtos;
using VehicleTracking.Presentation.Abstraction;

namespace VehicleTracking.Presentation.Controllers;
public class VehicleController(IMediator mediator) : ApiController(mediator)
{
    [HttpGet("[action]")]
    public async Task<ActionResult<IEnumerable<VehicleDto>>> Get(
       [FromQuery] int? id,
       [FromQuery] int customerId)
    {
        var result = await _mediator.Send(new GetVehiclesQuery(id, customerId));
        if (id.HasValue && !result.Any())
            return NotFound(); 
        return Ok(result);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update([FromBody] VehicleDto req)
    {
        await _mediator.Send(new UpdateVehicleCommand(
            req.Id, req.Plate, req.Status, req.HasBlokaj,
            req.HasCardReader, req.IsBlocked));
        return NoContent();
    }

}
