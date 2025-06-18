using VehicleTracking.Application.Features.DeviceFeatures.Queries;
using VehicleTracking.Domain.Dtos;

namespace VehicleTracking.Application.IServices
{
    public interface IDeviceService
    {
        Task<IEnumerable<DeviceDto>>GetDeviceAsync(GetDeviceQuery getDeviceQuery, CancellationToken cancellationToken);
    }
}
