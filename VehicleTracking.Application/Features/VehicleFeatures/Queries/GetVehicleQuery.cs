using MediatR;
using VehicleTracking.Application.IServices;
using VehicleTracking.Domain.Dtos;

namespace VehicleTracking.Application.Features.VehicleFeatures.Queries;

public sealed record GetVehiclesQuery(int? Id, int CustomerId) : IRequest<IEnumerable<VehicleDto>>;

public class Handler : IRequestHandler<GetVehiclesQuery, IEnumerable<VehicleDto>>
{
    private readonly IVehicleService _service;
    public Handler(IVehicleService service) => _service = service;

    public async Task<IEnumerable<VehicleDto>> Handle(GetVehiclesQuery req, CancellationToken ct)
    {
        return await _service.GetDriversAsync(req.Id, req.CustomerId);

    }
}
