using System.Net.Http.Json;
using System.Text.Json;
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
    
    public async Task<List<Reservation>> getReservationsToAccept()
    {
        HttpResponseMessage response = await client.GetAsync("https://localhost:7013/reservations");
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

    public async Task<Reservation> acceptPassenger(AcceptReservationDto dto)
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
}