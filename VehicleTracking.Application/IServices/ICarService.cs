using VehicleTracking.Application.Features.CarFeatures.Commands.UpdateCar;
using VehicleTracking.Domain.Dtos;

namespace VehicleTracking.Application.IServices
{
    public interface ICarService
    {
        Task<IEnumerable<MessageResponse>> UpdateCarAsync(UpdateCarQuery updateCar,CancellationToken cancellationToken);
    }
}
