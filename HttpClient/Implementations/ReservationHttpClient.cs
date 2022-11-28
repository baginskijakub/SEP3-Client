using System.Text.Json;
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
        HttpResponseMessage response = await client.getReservationsToAccept();
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

    public async Task<Reservation> acceptPassenger(int reservationId, bool didAccept)
    {
        HttpResponseMessage response = await client.acceptPassanger(reservationId, didAccept);
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