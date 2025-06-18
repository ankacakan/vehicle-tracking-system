using MediatR;
using VehicleTracking.Application.IServices;

namespace VehicleTracking.Application.Features.DriverFeatures.Queries;

public sealed record UpdateDriverCommand(
    int Id,
    string Name,
    string Status
) : IRequest<Unit>
{

    public class Handler : IRequestHandler<UpdateDriverCommand, Unit>
    {
        private readonly IDriverService _service;
        public Handler(IDriverService service) => _service = service;

        public Task<Unit> Handle(UpdateDriverCommand req, CancellationToken ct)
        {
          
            return _service.UpdateAsync(req, ct)
                           .ContinueWith(_ => Unit.Value, ct);
        }
    }
}


