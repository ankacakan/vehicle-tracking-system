using MediatR;
using VehicleTracking.Application.IServices;
using VehicleTracking.Domain.Dtos;

namespace VehicleTracking.Application.Features.DriverFeatures.Queries;

public sealed record GetDriverQuery(int? Id, int CustomerId) : IRequest<IEnumerable<DriverDto>>
{
    public class Handler
   : IRequestHandler<GetDriverQuery, IEnumerable<DriverDto>>
    {
        private readonly IDriverService _service;
        public Handler(IDriverService service)
            => _service = service;

        public Task<IEnumerable<DriverDto>> Handle(
            GetDriverQuery req,
            CancellationToken ct)
        {
            return _service.GetDriversAsync(req.CustomerId, ct);
        }
    }
}
