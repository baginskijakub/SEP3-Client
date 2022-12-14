namespace Domain.Models;

public class Ride
{
    public int Id
    {
        get;
        set;
    }
    public Location StartLocation { get; set; }
    public Location Destination { get; set; }
    public DateTime StartDate { get; set; }
    public int DriverId { get; set; }
    
    public string Status { get; set; }
    

    public Ride(Location destination, DateTime startDate, Location startLocation, int id, int driverId, string status)
    {
        Destination = destination;
        StartDate = startDate;
        StartLocation = startLocation;
        Id = id;
        DriverId = driverId;
        Status = status;
    }

    // public bool isBetweenDates(DateTime value)
    // {
    //     return StartDate <= value.epoch && value.epoch <= EndDate.epoch;
    // }
    

}