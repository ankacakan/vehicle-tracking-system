using MediatR;
using VehicleTracking.Application.IServices;
using VehicleTracking.Domain.Dtos;

namespace VehicleTracking.Application.Features.DeviceCommand.Queries;

public sealed record GetDeviceCommandsQuery(int UnitId)
    : IRequest<IEnumerable<DeviceCommandDto>>
{

    public class Handler
        : IRequestHandler<GetDeviceCommandsQuery, IEnumerable<DeviceCommandDto>>
    {
        private readonly IDeviceCommandService _svc;
        public Handler(IDeviceCommandService svc) => _svc = svc;

        public Task<IEnumerable<DeviceCommandDto>> Handle(
            GetDeviceCommandsQuery req,
            CancellationToken ct) =>
            _svc.ListByUnitAsync(req, ct);
    }
}
