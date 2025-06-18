using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleTracking.Application.Features.DeviceCommand.Commands;
using VehicleTracking.Application.Features.DeviceCommand.Queries;
using VehicleTracking.Domain.Dtos;
using VehicleTracking.Presentation.Abstraction;

namespace VehicleTracking.Presentation.Controllers;

public class DeviceCommandController(IMediator mediator) : ApiController(mediator)
{
    [HttpPost("[action]")]
    public async Task<ActionResult<int>> Send([FromBody] CreateDeviceCommandCommand cmd)
    {   
        var id = await _mediator.Send(cmd);
        return CreatedAtAction(nameof(GetByUnit), new { unitId = cmd.UnitId }, id);
    }

  
    [HttpGet("[action]")]
    public async Task<ActionResult<IEnumerable<DeviceCommandDto>>> GetByUnit(int unitId)
    {
        var list = await _mediator.Send(new GetDeviceCommandsQuery(unitId));
        return Ok(list);
    }
}
