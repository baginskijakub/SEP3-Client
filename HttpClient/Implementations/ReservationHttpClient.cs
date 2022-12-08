using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Domain.DTOs;
using Domain.Models;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class ReservationHttpClient : IReservationService
{
    private readonly HttpClient client;

    public ReservationHttpClient(HttpClient client)
    {
        this.client = client;
    }
    
    public async Task<List<Reservation>> GetReservationsToAccept(int driverId)
    {
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7013/reservations/driver/{driverId}");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        List<Reservation> reservations = JsonSerializer.Deserialize<List<Reservation>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return reservations;
        
    }

    public async Task<Reservation> AcceptPassenger(AcceptReservationDto dto)
    {
        
        HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:7013/reservations", dto);
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        Reservation? reservation = JsonSerializer.Deserialize<Reservation>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        return reservation;
    }

    public async Task<List<Reservation>> GetAcceptedReservationsByRideId(int rideId)
    {
        //endpoint to be changed as it uses same as getReservationsToAccept, dependent on controller implementation
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7013/reservations/{rideId}");
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
        
        List<Reservation> reservations = JsonSerializer.Deserialize<List<Reservation>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return reservations;
    }
}