using VehicleTracking.Application.Features.ReportFeatures.Queries;
using VehicleTracking.Application.IRepositories;
using VehicleTracking.Application.IServices;
using VehicleTracking.Domain.Dtos;

namespace VehicleTracking.Persistence.Services;

public class ReportService : IReportService
{
    private readonly IReportRepository _repo;
    public ReportService(IReportRepository repo) => _repo = repo;

    public async Task<IEnumerable<ReportDto>> GetVehicleReportsAsync(
        GetVehicleReportsQuery query,
        CancellationToken cancellationToken)
    {
        return await _repo.GetVehicleReportsAsync(
          query, cancellationToken);
    }
}
