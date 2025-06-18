using VehicleTracking.Domain.Entities;

namespace VehicleTracking.Application.IRepositories;

public interface IVehicleRepository
{
    Task<Vehicle> GetByIdAsync(int id);
    Task<IEnumerable<Vehicle>> ListByCustomerAsync(int customerId);
    Task UpdateAsync(Vehicle vehicle);
    Task UpdateDriverAsync(int vehicleId, int driverId);
    Task UpdateDeviceKmAsync(int unitId, decimal km);
    Task UpdateDeviceRuntimeAsync(int unitId, TimeSpan runtime);
    Task UpdateDeviceAssignmentAsync(int vehicleId, int? newDeviceId);
}
