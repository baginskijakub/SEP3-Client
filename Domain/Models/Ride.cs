namespace Domain.Models;

public class Ride
{
    public Location StartLocation { get; set; }
    public Location Destination { get; set; }

    public DateTime StartDate { get; set; }
    public int Id { get; set; }
    public string Driver { get; set; }

    public Ride(Location startLocation, Location destination, DateTime startDate, int id, string driver)
    {
        StartLocation = startLocation;
        Destination = destination;
        StartDate = startDate;
        Id = id;
        Driver = driver;
    }

    // public bool isBetweenDates(DateTime value)
    // {
    //     return StartDate <= value.epoch && value.epoch <= EndDate.epoch;
    // }
    
}