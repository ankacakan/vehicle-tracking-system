using AutoMapper;
using VehicleTracking.Application.IRepositories;
using VehicleTracking.Application.IServices;
using VehicleTracking.Domain.Dtos;

namespace VehicleTracking.Persistence.Services;

public class VehicleService(IVehicleRepository repo, IMapper mapper) : IVehicleService
{
    private readonly IVehicleRepository _repo = repo;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<VehicleDto>> GetDriversAsync(
    int? id,
    int customerId)
    {
        if (id.HasValue)
        {
            return _mapper.Map<IEnumerable<VehicleDto>>(await _repo.GetByIdAsync(id.Value));
        }
        else
        {
            return _mapper.Map<IEnumerable<VehicleDto>>(await _repo.ListByCustomerAsync(customerId));
        }
    }

    public Task UpdateDriverAsync(int vehicleId, int driverId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateDeviceKmAsync(int unitId, decimal km)
    {
        throw new NotImplementedException();
    }

    public Task UpdateDeviceRuntimeAsync(int unitId, TimeSpan runtime)
    {
        throw new NotImplementedException();
    }

    public Task UpdateDeviceAssignmentAsync(int vehicleId, int? newDeviceId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(VehicleDto request)
    {
        throw new NotImplementedException();
    }
}