using VehicleTracking.Application.Features.DriverFeatures.Queries;
using VehicleTracking.Domain.Dtos;

namespace VehicleTracking.Application.IServices;

public interface IDriverService
{
    Task<IEnumerable<DriverDto>> GetDriversAsync(
        int customerId,
        CancellationToken ct);

    Task UpdateAsync(UpdateDriverCommand cmd, CancellationToken ct);
}
