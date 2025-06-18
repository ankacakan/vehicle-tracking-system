using MediatR;
using VehicleTracking.Application.IServices;
using VehicleTracking.Domain.Dtos;
using VehicleTracking.Domain.Models;

namespace VehicleTracking.Application.Features.DeviceFeatures.Queries;

public sealed record GetDeviceQuery(string customerCode):IRequest<IEnumerable<DeviceDto>>
{
    public class Handler : IRequestHandler<GetDeviceQuery, IEnumerable<DeviceDto>>
    {
        private readonly IDeviceService _service;
        public Handler(IDeviceService service) => _service = service;

        public async Task<IEnumerable<DeviceDto>> Handle(
            GetDeviceQuery request,
            CancellationToken cancellationToken)
        {
            return await _service.GetDeviceAsync(request, cancellationToken);
        }
    }

}
