using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehicleTracking.Application.Features.AuthFeatures.Queries;
using VehicleTracking.Presentation.Abstraction;

namespace VehicleTracking.Presentation.Controllers;

public class AuthController(IMediator mediator) : ApiController(mediator)
{
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> GetToken([FromBody] LoginQuery query)
    {
        var jwt = await _mediator.Send(query);
        return Ok(new { token = jwt });
    }
}