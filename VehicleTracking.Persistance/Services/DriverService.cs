using AutoMapper;
using VehicleTracking.Application.Features.DriverFeatures.Queries;
using VehicleTracking.Application.IRepositories;
using VehicleTracking.Application.IServices;
using VehicleTracking.Domain.Dtos;

namespace VehicleTracking.Persistence.Services;

public class DriverService(IDriverRepository repo, IMapper mapper) : IDriverService
{
    private readonly IDriverRepository _repo = repo;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<DriverDto>> GetDriversAsync(
        int customerId,
        CancellationToken ct)
    {
        return _mapper.Map<IEnumerable<DriverDto>>(await _repo.ListByCustomerAsync(customerId));
    }

    public async Task UpdateAsync(
        UpdateDriverCommand cmd,
        CancellationToken ct)
    {
        var d = await _repo.GetByIdAsync(cmd.Id);
        if (cmd.Name is not null) d.Name = cmd.Name;
        await _repo.UpdateAsync(d);
    }
}