using MediatR;
using VehicleTracking.Application.IServices;

namespace VehicleTracking.Application.Features.DeviceCommand.Commands;

public sealed record CreateDeviceCommandCommand(
    int UnitId,
    string CommandType,
    string Param1,
    string Param2,
    string Param3
) : IRequest<int>

{
    public class Handler : IRequestHandler<CreateDeviceCommandCommand, int>
    {
        private readonly IDeviceCommandService _svc;
        public Handler(IDeviceCommandService svc) => _svc = svc;

        public Task<int> Handle(CreateDeviceCommandCommand req, CancellationToken ct) =>
            _svc.SendAsync(req, ct);
    }
}
