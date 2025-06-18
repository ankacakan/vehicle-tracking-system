namespace VehicleTracking.Domain.Dtos;

public record VehicleDto(
    int Id,
    string Plate,
    int? DeviceId,
    int? DriverId,
    string Status,
    bool HasBlokaj,
    bool HasCardReader,
    bool IsBlocked
);
