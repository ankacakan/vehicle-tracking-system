using Dapper;
using VehicleTracking.Application.IRepositories;
using VehicleTracking.Domain.Entities;
using VehicleTracking.Persistence.Data;

namespace VehicleTracking.Persistence.Repositories;

public class VehicleRepository : IVehicleRepository
{
    private readonly DapperContext _context;
    public VehicleRepository(DapperContext ctx) => _context = ctx;

    public async Task<Vehicle> GetByIdAsync(int id)
    {
         using var conn = _context.CreateConnection();
        const string sql = "SELECT * FROM Vehicles WHERE Id = @Id;";
        return await conn.QuerySingleOrDefaultAsync<Vehicle>(sql, new { Id = id });
    }

    public async Task<IEnumerable<Vehicle>> ListByCustomerAsync(int customerId)
    {
        using var conn = _context.CreateConnection();
        const string sql = "SELECT * FROM Vehicles WHERE CustomerId = @CustId;";
        return await conn.QueryAsync<Vehicle>(sql, new { CustId = customerId });
    }

    public async Task UpdateAsync(Vehicle v)
    {
        using var conn = _context.CreateConnection();
        const string sql = @"
                UPDATE Vehicles SET
                    Plate = @Plate,
                    Status = @Status,
                    HasBlokaj = @HasBlokaj,
                    HasCardReader = @HasCardReader,
                    IsBlocked = @IsBlocked
                WHERE Id = @Id;";
        await conn.ExecuteAsync(sql, v);
    }

    public async Task UpdateDriverAsync(int vehicleId, int driverId)
    {
        using var conn = _context.CreateConnection();
        const string sql = "UPDATE Vehicles SET DriverId = @DriverId WHERE Id = @Id;";
        await conn.ExecuteAsync(sql, new { DriverId = driverId, Id = vehicleId });
    }

    public async Task UpdateDeviceKmAsync(int unitId, decimal km)
    {
        using var conn = _context.CreateConnection();
        const string sql = "UPDATE Devices SET Km = @Km WHERE UnitId = @UnitId;";
        await conn.ExecuteAsync(sql, new { Km = km, UnitId = unitId });
    }

    public async Task UpdateDeviceRuntimeAsync(int unitId, TimeSpan runtime)
    {
        using var conn = _context.CreateConnection();
        const string sql = "UPDATE Devices SET Runtime = @Runtime WHERE UnitId = @UnitId;";
        await conn.ExecuteAsync(sql, new { Runtime = runtime, UnitId = unitId });
    }

    public async Task UpdateDeviceAssignmentAsync(int vehicleId, int? newDeviceId)
    {
        using var conn = _context.CreateConnection();
        const string sql = "UPDATE Vehicles SET DeviceId = @DevId WHERE Id = @Id;";
        await conn.ExecuteAsync(sql, new { DevId = newDeviceId, Id = vehicleId });
    }


}
