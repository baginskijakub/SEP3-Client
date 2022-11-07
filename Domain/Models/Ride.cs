namespace Domain.Models;

public class Ride
{
    public Location startLocation { get; set; }
    public Location destination { get; set; }
    public DateTime dateTime { get; set; }
    
    public int id { get; set; }
    public string driver { get; set; }
}