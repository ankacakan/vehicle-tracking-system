namespace VehicleTracking.Domain.Dtos;

public record DeviceCommandDto(
    int Id,
    int UnitId,
    string CommandType,
    string Param1,
    string Param2,
    string Param3,
    string Status,
    DateTime CreatedAt
);
