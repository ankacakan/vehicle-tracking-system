namespace VehicleTracking.Domain.Entities;

public class Driver
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int CustomerId { get; set; }         
}
