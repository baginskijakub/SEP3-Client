namespace Domain.Models;

public class Ride
{
<<<<<<< HEAD
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
=======
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
>>>>>>> 9377c377bd76b5d36a5e260c7978fc3642f4f8b5
        Id = id;
        Driver = driver;
    }

    // public bool isBetweenDates(DateTime value)
    // {
<<<<<<< HEAD
    //     return StartDate <= value.epoch && value.epoch <= EndDate.epoch;
    // }
    
=======
    //     return startDate.epoch <= value.epoch && value.epoch <= endDate.epoch;
    // }
>>>>>>> 9377c377bd76b5d36a5e260c7978fc3642f4f8b5
}