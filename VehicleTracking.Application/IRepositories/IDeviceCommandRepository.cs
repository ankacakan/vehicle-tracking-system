using VehicleTracking.Domain.Entities;

namespace VehicleTracking.Application.IRepositories;

public interface IDeviceCommandRepository
{
    Task<int> CreateAsync(DeviceCommand cmd);
    Task<IEnumerable<DeviceCommand>> ListByUnitAsync(int unitId);
}
