using FluentValidation;
using VehicleTracking.Application.Features.DeviceCommand.Commands;

namespace VehicleTracking.Application.Validators
{
    public class CreateDeviceCommandCommandValidator : AbstractValidator<CreateDeviceCommandCommand>
    {
        public CreateDeviceCommandCommandValidator()
        {
            RuleFor(x => x.UnitId)
             .GreaterThan(0)
             .WithMessage("UnitId 0’dan büyük olmalı.");

            RuleFor(x => x.CommandType)
                .NotEmpty()
                .WithMessage("CommandType boş olamaz.")
                .MaximumLength(50)
                .WithMessage("CommandType en fazla 50 karakter olabilir.");

            When(x => x.Param1 != null, () =>
            {
                RuleFor(x => x.Param1)
                    .NotEmpty()
                    .WithMessage("Param1 boş olamaz.")
                    .MaximumLength(100)
                    .WithMessage("Param1 en fazla 100 karakter olabilir.");
            });

            When(x => x.Param2 != null, () =>
            {
                RuleFor(x => x.Param2)
                    .NotEmpty()
                    .WithMessage("Param2 boş olamaz.")
                    .MaximumLength(100)
                    .WithMessage("Param2 en fazla 100 karakter olabilir.");
            });

            When(x => x.Param3 != null, () =>
            {
                RuleFor(x => x.Param3)
                    .NotEmpty()
                    .WithMessage("Param3 boş olamaz.")
                    .MaximumLength(100)
                    .WithMessage("Param3 en fazla 100 karakter olabilir.");
            });
        }
    }
}
