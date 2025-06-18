using Dapper;
using VehicleTracking.Application.Features.ReportFeatures.Queries;
using VehicleTracking.Application.IRepositories;
using VehicleTracking.Domain.Dtos;
using VehicleTracking.Persistence.Data;

namespace VehicleTracking.Persistence.Repositories;

public class ReportRepository : IReportRepository
{
    private readonly DapperContext _context;

    public ReportRepository(DapperContext context) => _context = context;

    public async Task<IEnumerable<ReportDto>> GetVehicleReportsAsync(GetVehicleReportsQuery getVehicleReportsQuery,CancellationToken cancellationToken)
    {
        using var conn = _context.CreateConnection();
        const string sql = @"
          select top 10 * from surucurapor as r  with(nolock) where r.CIHAZID=@CIHAZID  AND r.TARIH BETWEEN @From AND @To
             ORDER BY r.TARIH;
            ";
        return await conn.QueryAsync<ReportDto>(sql, new
        {
            CIHAZID = getVehicleReportsQuery.request.CihazId,
            getVehicleReportsQuery.request.From,
            getVehicleReportsQuery.request.To
        });
    }


}
