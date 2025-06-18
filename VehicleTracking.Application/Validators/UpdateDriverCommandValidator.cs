using FluentValidation;
using VehicleTracking.Application.Features.DriverFeatures.Queries;

namespace VehicleTracking.Application.Validators
{
    public class UpdateDriverCommandValidator : AbstractValidator<UpdateDriverCommand>
    {
        public UpdateDriverCommandValidator()
        {
            RuleFor(x => x.Id)
      .NotEmpty().WithMessage("Sürücü ID’si zorunlu.")
      .GreaterThan(0).WithMessage("Sürücü ID’si sıfırdan büyük olmalı.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Sürücü adı zorunlu.")
                .MaximumLength(100).WithMessage("Sürücü adı en fazla 100 karakter olabilir.");

        }
    }
}
