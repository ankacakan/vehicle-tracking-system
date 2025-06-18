using FluentValidation;
using VehicleTracking.Application.Features.DeviceFeatures.Queries;

namespace VehicleTracking.Application.Validators;

public class GetDeviceQueryValidator : AbstractValidator<GetDeviceQuery>
{
    public GetDeviceQueryValidator()
    {
        RuleFor(x => x.customerCode)
            .NotEmpty().WithMessage("Customer code alanı zorunlu.")
            .Length(1, 50).WithMessage("Customer code 1 ve 50 karakter uzunluğunda olabilir.");
    }
}
