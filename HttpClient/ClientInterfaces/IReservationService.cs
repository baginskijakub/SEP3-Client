using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IReservationService
{
    Task<List<Reservation>> GetReservationsToAccept(int driverId);

    Task<Reservation> AcceptPassenger(AcceptReservationDto dto);
    
    Task<List<Reservation>> GetAcceptedReservationsByRideId(int rideId);
}