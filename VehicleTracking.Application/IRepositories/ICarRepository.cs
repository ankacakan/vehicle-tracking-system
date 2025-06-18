using VehicleTracking.Application.Features.CarFeatures.Commands.UpdateCar;
using VehicleTracking.Domain.Dtos;

namespace VehicleTracking.Application.IRepositories;

public interface ICarRepository
{
    Task<IEnumerable<MessageResponse>> UpdateCarAsync(UpdateCarQuery updateCar, CancellationToken cancellationToken);
}
