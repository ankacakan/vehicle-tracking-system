using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleTracking.Application.Features.DeviceFeatures.Queries;
using VehicleTracking.Domain.Models;
using VehicleTracking.Presentation.Abstraction;

namespace VehicleTracking.Presentation.Controllers;


public class DevicesController(IMediator mediator) : ApiController(mediator)
{
    [HttpPost("[action]")]
    public async Task<IActionResult>Get([FromQuery] string customerCode, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetDeviceQuery(customerCode), cancellationToken));
    }
}
