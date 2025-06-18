using VehicleTracking.Application.Features.ReportFeatures.Queries;
using VehicleTracking.Domain.Dtos;

namespace VehicleTracking.Application.IServices;

public interface  IReportService
{
    Task<IEnumerable<ReportDto>> GetVehicleReportsAsync(GetVehicleReportsQuery getVehicleReportsQuery,CancellationToken cancellationToken);
}
