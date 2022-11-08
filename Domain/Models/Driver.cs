using System.Collections;
using System.Xml.Serialization;

namespace Domain.Models;

public class Driver
{
    public string name { get; set; }
    public Location startLocation { get; set; }
    public List<Ride> rides { get; set; }

    public Driver(string name)
    {
        this.name = name;
        rides = new List<Ride>();
    }

    public void addRide(Ride ride)
    {
        rides.Add(ride);
    }

    public void removeRide(Ride ride)
    {
        rides.Remove(ride);
    }

    public List<Ride> getRidesByStartLocation(Location startLocation)
    {
        List<Ride> ridesByStartLocation = new List<Ride>();
        
        for (int i = 0; i < rides.Count; i++)
        {
            if (startLocation.Equals(rides[i].startLocation))
            {
                ridesByStartLocation.Add(rides[i]);
            }
        }

        return ridesByStartLocation;
    }

    public List<Ride> getRidesByDestination(Location destination)
    {
        List<Ride> ridesByDestination = new List<Ride>();

        for (int i = 0; i < rides.Count; i++)
        {
            if (destination.Equals(rides[i].destination))
            {
                ridesByDestination.Add(rides[i]);
            }
        }

        return ridesByDestination;
    }

    public List<Ride> getRidesByDate(long epochStart)
    {
        List<Ride> ridesByDate = new List<Ride>();

        for (int i = 0; i < rides.Count; i++)
        {
            if (epochStart.Equals(rides[i].startDate))
            {
                ridesByDate.Add(rides[i]);
            }
        }

        return ridesByDate;
    }
}
