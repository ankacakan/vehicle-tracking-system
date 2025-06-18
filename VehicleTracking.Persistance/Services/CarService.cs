using VehicleTracking.Application.Features.CarFeatures.Commands.UpdateCar;
using VehicleTracking.Application.IRepositories;
using VehicleTracking.Application.IServices;
using VehicleTracking.Domain.Dtos;

namespace VehicleTracking.Persistence.Services;

public class CarService : ICarService
{

    private readonly ICarRepository _carRepository;
    public CarService(ICarRepository repo) => _carRepository = repo;

    public async Task<IEnumerable<MessageResponse>> UpdateCarAsync(UpdateCarQuery updateCar, CancellationToken cancellationToken)
    {
        return await _carRepository.UpdateCarAsync(updateCar,cancellationToken);
    }
}
