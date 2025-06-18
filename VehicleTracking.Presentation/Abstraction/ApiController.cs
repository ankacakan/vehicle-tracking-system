using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VehicleTracking.Presentation.Abstraction;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public abstract class ApiController : ControllerBase
{
    public readonly IMediator _mediator;
    protected ApiController(IMediator mediator)
    {
            _mediator = mediator;
    }
}
