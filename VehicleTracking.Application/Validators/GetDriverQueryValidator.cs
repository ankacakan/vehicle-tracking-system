using FluentValidation;
using VehicleTracking.Application.Features.DriverFeatures.Queries;

namespace VehicleTracking.Application.Validators
{
    public class GetDriverQueryValidator : AbstractValidator<GetDriverQuery>
    {
        public GetDriverQueryValidator()
        {
            RuleFor(x => x.CustomerId)
                .GreaterThan(0)
                .WithMessage("CustomerId 0’dan büyük olmalı.");
            RuleFor(x => x.Id)
                .GreaterThanOrEqualTo(0)
                .When(x => x.Id.HasValue)
                .WithMessage("Id 0’dan büyük olmalı..");
        }
    }
}
