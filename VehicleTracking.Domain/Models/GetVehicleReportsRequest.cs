namespace VehicleTracking.Domain.Models;

public class GetVehicleReportsRequest
{
    public string CihazId { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
}
