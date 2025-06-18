namespace VehicleTracking.Domain.Entities;

public class Device
{
    public DateTime ILKSINYALTARIH { get; set; }
    public string CIHAZTIPI { get; set; }
    public string CIHAZID { get; set; }
    public string IMEINO { get; set; }
    public string SERVERIP { get; set; }
    public DateTime LASTSTOP { get; set; }
    public DateTime SKTARIH { get; set; }
    public string DURUM { get; set; }
}
