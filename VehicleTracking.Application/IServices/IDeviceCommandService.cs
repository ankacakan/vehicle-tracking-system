using VehicleTracking.Application.Features.DeviceCommand.Commands;
using VehicleTracking.Application.Features.DeviceCommand.Queries;
using VehicleTracking.Domain.Dtos;

namespace VehicleTracking.Application.IServices;

public interface IDeviceCommandService
{
    Task<int> SendAsync(CreateDeviceCommandCommand cmd, CancellationToken ct);
    Task<IEnumerable<DeviceCommandDto>> ListByUnitAsync(GetDeviceCommandsQuery qry, CancellationToken ct);
}
