using FluentValidation;
using VehicleTracking.Application.Features.DeviceCommand.Queries;

namespace VehicleTracking.Application.Validators
{
    public class GetDeviceCommandsQueryValidator : AbstractValidator<GetDeviceCommandsQuery>
    {
        public GetDeviceCommandsQueryValidator()
        {
            RuleFor(x => x.UnitId)
        .GreaterThan(0)
        .WithMessage("UnitId 0’dan büyük olmalı.");
        }
    }
}
