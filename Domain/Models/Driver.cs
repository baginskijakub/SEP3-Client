using System.Collections;
using System.Xml.Serialization;

namespace Domain.Models;

public class Driver
{
    public string Name { get; set; }
    public List<Ride> Rides { get; set; }

    public Driver(string name)
    {
        Name = name;
        Rides = new List<Ride>();
    }

    public void addRide(Ride ride)
    {
        Rides.Add(ride);
    }

    public void removeRide(Ride ride)
    {
        Rides.Remove(ride);
    }

    public List<Ride> getRidesByStartLocation(Location startLocation)
    {
        List<Ride> ridesByStartLocation = new List<Ride>();
        
        for (int i = 0; i < Rides.Count; i++)
        {
            if (startLocation.Equals(Rides[i].StartLocation))
            {
                ridesByStartLocation.Add(Rides[i]);
            }
        }

        return ridesByStartLocation;
    }

    public List<Ride> getRidesByDestination(Location destination)
    {
        List<Ride> ridesByDestination = new List<Ride>();

        for (int i = 0; i < Rides.Count; i++)
        {
            if (destination.Equals(Rides[i].Destination))
            {
                ridesByDestination.Add(Rides[i]);
            }
        }

        return ridesByDestination;
    }

    public List<Ride> getRidesByDate(long epochStart)
    {
        List<Ride> ridesByDate = new List<Ride>();

        for (int i = 0; i < Rides.Count; i++)
        {
            if (epochStart.Equals(Rides[i].StartDate))
            {
                ridesByDate.Add(Rides[i]);
            }
        }

        return ridesByDate;
    }
}
