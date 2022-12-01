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
    public string Driver { get; set; }
    

    public Ride(Location destination, DateTime startDate, Location startLocation, int id, string driver )
    {
        Destination = destination;
        StartDate = startDate;
        StartLocation = startLocation;
        Id = id;
        Driver = driver;
    }

    // public bool isBetweenDates(DateTime value)
    // {
    //     return StartDate <= value.epoch && value.epoch <= EndDate.epoch;
    // }
    

}