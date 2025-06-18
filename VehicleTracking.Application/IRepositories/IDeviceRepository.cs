using VehicleTracking.Application.Features.DeviceCommand.Queries;
using VehicleTracking.Application.Features.DeviceFeatures.Queries;
using VehicleTracking.Domain.Entities;
namespace VehicleTracking.Application.IRepositories;

public interface IDeviceRepository
{
    Task<IEnumerable<Device>> GetAsync(GetDeviceQuery getDevice, CancellationToken cancellationToken);
}
