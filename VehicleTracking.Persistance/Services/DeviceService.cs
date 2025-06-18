using AutoMapper;
using VehicleTracking.Application.Features.DeviceFeatures.Queries;
using VehicleTracking.Application.IRepositories;
using VehicleTracking.Application.IServices;
using VehicleTracking.Domain.Dtos;

namespace VehicleTracking.Persistence.Services;

public class DeviceService(IDeviceRepository repo, IMapper mapper) : IDeviceService
{
    private readonly IDeviceRepository _repo = repo;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<DeviceDto>> GetDeviceAsync(GetDeviceQuery getDeviceQuery, CancellationToken cancellationToken)
    {
       return _mapper.Map<IEnumerable<DeviceDto>>(await _repo.GetAsync(getDeviceQuery, cancellationToken));
    }
}
