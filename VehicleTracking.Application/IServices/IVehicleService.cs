using VehicleTracking.Domain.Dtos;

namespace VehicleTracking.Application.IServices;

public interface IVehicleService
{
    Task<IEnumerable<VehicleDto>> GetDriversAsync(int? id,int customerId);
    Task UpdateAsync(VehicleDto request);
    Task UpdateDriverAsync(int vehicleId, int driverId);
    Task UpdateDeviceKmAsync(int unitId, decimal km);
    Task UpdateDeviceRuntimeAsync(int unitId, TimeSpan runtime);
    Task UpdateDeviceAssignmentAsync(int vehicleId, int? newDeviceId);
}
