using FluentValidation;
using VehicleTracking.Application.Features.VehicleFeatures.Commands.UpdateVehicle;

namespace VehicleTracking.Application.Validators;

public class UpdateVehicleCommandValidator : AbstractValidator<UpdateVehicleCommand>
{
    static readonly string[] ValidStatuses = { "aktif", "pasif", "silindi" };

    public UpdateVehicleCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Araç Id’si zorunlu.");

        When(x => x.Plate != null, () =>
            RuleFor(x => x.Plate)
                .NotEmpty().WithMessage("Plaka boş olamaz.")
                .MaximumLength(20).WithMessage("Plaka max 20 karakter.")
        );

        When(x => x.Status != null, () =>
            RuleFor(x => x.Status)
                .Must(s => ValidStatuses.Contains(s))
                .WithMessage("Status değeri geçersiz.")
        );
    }
}
