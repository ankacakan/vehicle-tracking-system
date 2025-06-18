using Dapper;
using VehicleTracking.Application.IRepositories;
using VehicleTracking.Domain.Entities;
using VehicleTracking.Persistence.Data;

namespace VehicleTracking.Persistence.Repositories;

public class DeviceCommandRepository : IDeviceCommandRepository
{
    private readonly DapperContext _ctx;
    public DeviceCommandRepository(DapperContext ctx) => _ctx = ctx;

    public async Task<int> CreateAsync(DeviceCommand cmd)
    {
         using var conn = _ctx.CreateConnection();
        const string sql = @"
                INSERT INTO DeviceCommands
                    (UnitId, CommandType, Param1, Param2, Param3, Status, CreatedAt)
                VALUES
                    (@UnitId, @CommandType, @Param1, @Param2, @Param3, @Status, @CreatedAt);
                SELECT CAST(SCOPE_IDENTITY() AS int);
            ";
        return await conn.QuerySingleAsync<int>(sql, cmd);
    }

    public async Task<IEnumerable<DeviceCommand>> ListByUnitAsync(int unitId)
    {
        using var conn = _ctx.CreateConnection();
        const string sql = @"
                SELECT * FROM DeviceCommands
                 WHERE UnitId = @UnitId
                 ORDER BY CreatedAt DESC;
            ";
        return await conn.QueryAsync<DeviceCommand>(sql, new { UnitId = unitId });
    }
}
