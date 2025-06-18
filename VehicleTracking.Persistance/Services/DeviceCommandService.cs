using AutoMapper;
using VehicleTracking.Application.Features.DeviceCommand.Commands;
using VehicleTracking.Application.Features.DeviceCommand.Queries;
using VehicleTracking.Application.IRepositories;
using VehicleTracking.Application.IServices;
using VehicleTracking.Domain.Dtos;
using VehicleTracking.Domain.Entities;

namespace VehicleTracking.Persistence.Services;

public class DeviceCommandService(IDeviceCommandRepository deviceCommand, IMapper mapper) : IDeviceCommandService
{
    private readonly IDeviceCommandRepository _repo = deviceCommand;
    private readonly IMapper _mapper = mapper;

    public Task<int> SendAsync(CreateDeviceCommandCommand cmd, CancellationToken ct)
    {
        var entity = new DeviceCommand
        {
            UnitId = cmd.UnitId,
            CommandType = cmd.CommandType,
            Param1 = cmd.Param1,
            Param2 = cmd.Param2,
            Param3 = cmd.Param3,
            Status = "Pending",
            CreatedAt = DateTime.UtcNow
        };
        return _repo.CreateAsync(entity);
    }

    public async Task<IEnumerable<DeviceCommandDto>> ListByUnitAsync(GetDeviceCommandsQuery qry, CancellationToken ct)
    {
        return _mapper.Map<IEnumerable<DeviceCommandDto>>(await _repo.ListByUnitAsync(qry.UnitId));
    }
}
