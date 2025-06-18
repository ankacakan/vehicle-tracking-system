using MediatR;
using VehicleTracking.Application.IRepositories;
using VehicleTracking.Domain.Dtos;

namespace VehicleTracking.Application.Features.CarFeatures.Commands.UpdateCar;

public sealed record UpdateCarQuery(string licensePlate, int status, string updateLicensePlate) : IRequest<IEnumerable<MessageResponse>>
{
    public class Handler : IRequestHandler<UpdateCarQuery, IEnumerable<MessageResponse>>
    {
        private readonly ICarRepository _service;

        public Handler(ICarRepository service) => _service = service;

        public async Task<IEnumerable<MessageResponse>> Handle(UpdateCarQuery request, CancellationToken cancellationToken)
        {
            return await _service.UpdateCarAsync(
               request, cancellationToken);
        }
    }
}
