namespace VehicleTracking.Domain.Dtos;

public class ReportDto
{
    public int ID { get; set; }
    public string CIHAZID { get; set; }
    public DateTime TARIH { get; set; }
    public string KIMLIKID { get; set; }
    public int KIMLIKYON { get; set; }
}
