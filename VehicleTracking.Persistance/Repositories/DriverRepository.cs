using Dapper;
using VehicleTracking.Application.IRepositories;
using VehicleTracking.Domain.Entities;
using VehicleTracking.Persistence.Data;

namespace VehicleTracking.Persistence.Repositories;

public class DriverRepository : IDriverRepository
{
    private readonly DapperContext _ctx;
    public DriverRepository(DapperContext ctx) => _ctx = ctx;

    public async Task<Driver> GetByIdAsync(int id)
    {
         using var conn = _ctx.CreateConnection();
        const string sql = "select KIMLIKID AS Id,ADSOYAD AS Name,USERID AS CustomerId from surucukimlik with(nolock) where ID = @Id;";
        return await conn.QuerySingleOrDefaultAsync<Driver>(sql, new { Id = id });
    }

    public async Task<IEnumerable<Driver>> ListByCustomerAsync(int customerId)
    {
         using var conn = _ctx.CreateConnection();
        const string sql = "select KIMLIKID AS Id,ADSOYAD AS Name,USERID AS CustomerId from surucukimlik with(nolock) where USERID= @CustId;";
        return await conn.QueryAsync<Driver>(sql, new { CustId = customerId });
    }

    public async Task UpdateAsync(Driver d)
    {
        using var conn = _ctx.CreateConnection();
        const string sql = @"
                UPDATE surucukimlik SET
                    ADSOYAD   = @Name
                WHERE ID = @Id;";
        await conn.ExecuteAsync(sql, d);
    }
}
