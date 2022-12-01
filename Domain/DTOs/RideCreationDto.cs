using Domain.Models;

namespace Domain.DTOs;

public class RideCreationDto
{
    public int DriverId { get; set; }
    public string Date { get; set; }
    public string Time { get; set; }
    public int Capacity { get; set; }
    public Location StartLocation { get; set; }
    public Location Destination { get; set; }
}