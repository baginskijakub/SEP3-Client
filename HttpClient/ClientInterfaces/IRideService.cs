﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IRideService
{
    Task<List<Ride>> GetAllRidesAsync();

    Task JoinRide(JoinRideDto dto);

    Task<Ride?> GetRideById(int id);

    Task<Ride> CreateRide(RideCreationDto creationDto);
}