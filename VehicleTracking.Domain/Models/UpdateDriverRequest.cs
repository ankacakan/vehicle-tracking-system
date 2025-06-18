namespace VehicleTracking.Domain.Models;

public record UpdateDriverRequest(
    int Id,
    string Name,
    string Status
);
