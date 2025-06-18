using MediatR;
using VehicleTracking.Application.IRepositories;
using VehicleTracking.Domain.Dtos;

namespace VehicleTracking.Application.Features.VehicleFeatures.Queries;

public sealed record ListVehiclesQuery(int CustomerId) : IRequest<IEnumerable<VehicleDto>>
{
    public class Handler : IRequestHandler<ListVehiclesQuery, IEnumerable<VehicleDto>>
    {
        private readonly IVehicleRepository _repo;
        public Handler(IVehicleRepository repo) => _repo = repo;
        public async Task<IEnumerable<VehicleDto>> Handle(ListVehiclesQuery req, CancellationToken ct)
        {
            var list = await _repo.ListByCustomerAsync(req.CustomerId);
            return list.Select(v => new VehicleDto(
                v.Id, v.Plate, v.DeviceId, v.DriverId,
                v.Status, v.HasBlokaj, v.HasCardReader, v.IsBlocked
            ));
        }
    }
}
