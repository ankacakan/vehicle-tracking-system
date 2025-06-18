namespace VehicleTracking.Domain.Entities;

public class DeviceCommand
{
    public int Id { get; set; }
    public int UnitId { get; set; }
    public string CommandType { get; set; } = null!;
    public string Param1 { get; set; }
    public string Param2 { get; set; }
    public string Param3 { get; set; }
    public string Status { get; set; } = "Pending";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
