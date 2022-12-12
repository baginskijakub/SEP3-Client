using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
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
        
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",LoginHttpClient.Jwt);

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
        
        
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",LoginHttpClient.Jwt);

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
        
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",LoginHttpClient.Jwt);

        HttpResponseMessage response = await client.GetAsync($"https://localhost:7013/reservations/ride/{rideId}");
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

    public async Task<List<Reservation>> GetReservationsByUserId(int userId)
    {
                
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",LoginHttpClient.Jwt);

        //url ot change
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7013/reservations/ride/user/{userId}");
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

    public async Task<bool> ChangeReservationStatus(ChangeReservationStatusDto dto)
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",LoginHttpClient.Jwt);
        
        //url to change
        HttpResponseMessage response = await client.PostAsJsonAsync($"https://localhost:7013/reservations/ride/user/", dto);
        string result = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine(result);
            throw new Exception(result);
        }

        return true;
    }
}