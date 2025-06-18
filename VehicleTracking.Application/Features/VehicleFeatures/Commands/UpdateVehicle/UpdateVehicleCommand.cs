using MediatR;
using VehicleTracking.Application.IRepositories;

namespace VehicleTracking.Application.Features.VehicleFeatures.Commands.UpdateVehicle;

public sealed record UpdateVehicleCommand(
    int Id,
    string Plate,
    string Status,
    bool? HasBlokaj,
    bool? HasCardReader,
    bool? IsBlocked
) : IRequest<Unit>

{
    public class Handler : IRequestHandler<UpdateVehicleCommand, Unit>
    {
        private readonly IVehicleRepository _repo;
        public Handler(IVehicleRepository repo) => _repo = repo;
        public async Task<Unit> Handle(UpdateVehicleCommand req, CancellationToken cancellationToken)
        {
            var v = await _repo.GetByIdAsync(req.Id);
            if (v == null) throw new KeyNotFoundException("Araç bulunamadı");

            if (req.Plate is not null) v.Plate = req.Plate;
            if (req.Status is not null) v.Status = req.Status;
            if (req.HasBlokaj is not null) v.HasBlokaj = req.HasBlokaj.Value;
            if (req.HasCardReader is not null) v.HasCardReader = req.HasCardReader.Value;
            if (req.IsBlocked is not null) v.IsBlocked = req.IsBlocked.Value;

            await _repo.UpdateAsync(v);
            return Unit.Value;
        }
    }

}
