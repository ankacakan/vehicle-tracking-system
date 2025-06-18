namespace VehicleTracking.Domain.Entities;

public class Vehicle
{
    public int Id { get; set; }
    public string Plate { get; set; } = null!;
    public int? DeviceId { get; set; }
    public int? DriverId { get; set; }
    public string Status { get; set; } = "aktif"; 
    public bool HasBlokaj { get; set; }
    public bool HasCardReader { get; set; }
    public bool IsBlocked { get; set; }
}
