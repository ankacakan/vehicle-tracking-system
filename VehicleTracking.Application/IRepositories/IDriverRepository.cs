using VehicleTracking.Domain.Entities;

namespace VehicleTracking.Application.IRepositories;

public interface IDriverRepository
{
    Task<Driver> GetByIdAsync(int id);
    Task<IEnumerable<Driver>> ListByCustomerAsync(int customerId);
    Task UpdateAsync(Driver driver);
}
