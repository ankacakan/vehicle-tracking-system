using MediatR;
using VehicleTracking.Application.IServices;
using VehicleTracking.Domain.Dtos;
using VehicleTracking.Domain.Models;

namespace VehicleTracking.Application.Features.ReportFeatures.Queries;

public sealed record GetVehicleReportsQuery(GetVehicleReportsRequest request)
    : IRequest<IEnumerable<ReportDto>>
{
    public class Handler : IRequestHandler<GetVehicleReportsQuery, IEnumerable<ReportDto>>
    {
        private readonly IReportService _service;
        public Handler(IReportService service) => _service = service;

        public async Task<IEnumerable<ReportDto>> Handle(
            GetVehicleReportsQuery request,
            CancellationToken cancellationToken)
        {
            return await _service.GetVehicleReportsAsync(request, cancellationToken);
        }
    }
}
