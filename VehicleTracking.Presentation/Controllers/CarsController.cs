using MediatR;
using VehicleTracking.Presentation.Abstraction;

namespace VehicleTracking.Presentation.Controllers;

public sealed class CarsController(IMediator mediator) : ApiController(mediator)
{



}
