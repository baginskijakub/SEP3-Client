using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IRideService
{
    Task<List<Ride>> GetAllRidesAsync(string? startDate, string? endDate);

    Task JoinRide(JoinRideDto dto);

    Task<Ride?> GetRideById(int id);

    Task<Ride> CreateRide(RideCreationDto creationDto);
    
    Task<List<Ride>> GetRidesByDriverId(int driverId);
}