using VehicleTracking.Application.Features.ReportFeatures.Queries;
using VehicleTracking.Domain.Dtos;

namespace VehicleTracking.Application.IRepositories;

public interface IReportRepository
{
    Task<IEnumerable<ReportDto>> GetVehicleReportsAsync(GetVehicleReportsQuery getVehicleReportsQuery,CancellationToken cancellationToken);
}
