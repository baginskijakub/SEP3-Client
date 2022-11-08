namespace Domain.Models;

public class Ride
{
    public Location startLocation { get; set; }
    public Location destination { get; set; }
    public DateTime dateTime { get; set; }
    
    public DateTime startDate { get; set; }
    
    public DateTime endDate { get; set; }
    public int id { get; set; }
    public string driver { get; set; }
    

    public Ride(Location destination, DateTime time)
    {
        this.destination = destination;
        dateTime = time;
    }

    public bool isBetweenDates(DateTime value)
    {
        return startDate.epoch <= value.epoch && value.epoch <= endDate.epoch;
    }
}