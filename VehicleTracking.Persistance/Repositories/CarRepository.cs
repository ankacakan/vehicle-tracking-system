using Dapper;
using VehicleTracking.Application.Features.CarFeatures.Commands.UpdateCar;
using VehicleTracking.Application.IRepositories;
using VehicleTracking.Domain.Dtos;
using VehicleTracking.Persistence.Data;

namespace VehicleTracking.Persistence.Repositories;

public class CarRepository : ICarRepository
{
    private readonly DapperContext _context;

    public CarRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MessageResponse>> UpdateCarAsync(UpdateCarQuery updateCar,CancellationToken cancellationToken)
    {
        using var conn = _context.CreateConnection();
        const string sql = @"
            UPDATE Cars
            SET 
                LicensePlate = @UpdateLicensePlate,
                Status       = @Status
            WHERE 
                LicensePlate = @OldLicensePlate;
        ";

        var affectedRows = await conn.ExecuteAsync(sql, new
        {
            OldLicensePlate = updateCar.licensePlate,
            UpdateLicensePlate = updateCar.updateLicensePlate,
            Status = updateCar.status
        });

        var msg = affectedRows > 0 ? "Güncellendi" : "Güncelleme başarısız";
        return [new MessageResponse(msg)];
    }


}
