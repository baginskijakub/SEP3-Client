using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IReservationService
{
    Task<List<Reservation>> getReservationsToAccept();

    Task<Reservation> acceptPassenger(AcceptReservationDto dto);
}