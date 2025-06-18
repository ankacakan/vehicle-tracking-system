using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehicleTracking.Application.Features.ReportFeatures.Queries;
using VehicleTracking.Domain.Models;
using VehicleTracking.Presentation.Abstraction;

namespace VehicleTracking.Presentation.Controllers;
public class ReportsController(IMediator mediator) : ApiController(mediator)
{
    [Authorize]
    [HttpPost("[action]")]
    public async Task<IActionResult> GetVehicle(
        [FromQuery] GetVehicleReportsRequest request,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetVehicleReportsQuery(request), cancellationToken);
        return Ok(result);
    }



}

