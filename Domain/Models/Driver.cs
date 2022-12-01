using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Domain.Models;

public class Driver
{
    public string Name { get; set; }
    public List<Ride> Rides { get; set; }

    public int LicenseNumber
    {
        get;
        set;
    }
    
    public string Email { get; set; }
    public int Id { get; set; }
    public int Phone { get; set; }
    public string Password { get; set; }

    public Driver(string name)
    {
        Name = name;
        Rides = new List<Ride>();
    }

    public Driver()
    {
        
    }

    public void AddRide(Ride ride)
    {
        Rides.Add(ride);
    }

    public void RemoveRide(Ride ride)
    {
        Rides.Remove(ride);
    }

    public List<Ride> GetRidesByStartLocation(Location startLocation)
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

    public List<Ride> GetRidesByDestination(Location destination)
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

    public List<Ride> GetRidesByDate(long epochStart)
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
