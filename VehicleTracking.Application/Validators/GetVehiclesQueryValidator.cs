using FluentValidation;
using VehicleTracking.Application.Features.VehicleFeatures.Queries;

namespace VehicleTracking.Application.Validators
{
    public class GetVehiclesQueryValidator : AbstractValidator<GetVehiclesQuery>
    {
        public GetVehiclesQueryValidator()
        {
            RuleFor(x => x.CustomerId)
                .GreaterThan(0)
                .WithMessage("CustomerId 0’dan büyük olmalı.");

            When(x => x.Id.HasValue, () =>
            {
                RuleFor(x => x.Id!.Value) 
                    .GreaterThan(0)
                    .WithMessage("Id 0’dan büyük olmalı.");
            });
        }
    }
}
