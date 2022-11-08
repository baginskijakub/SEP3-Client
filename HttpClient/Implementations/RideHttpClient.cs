using System.Net.Http.Json;
using System.Text.Json;
using Domain.DTOs;
using Domain.Models;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class RideHttpClient : IRideService
{
    private readonly HttpClient client;

    public RideHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<List<Ride?>> GetAllRidesAsync()
    {
        HttpResponseMessage response = await client.GetAsync("/rides");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        List<Ride?> rides = JsonSerializer.Deserialize<List<Ride?>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return rides;
    }
    
    public async Task<Ride?> GetRideById(int id)
    {
        HttpResponseMessage response = await client.GetAsync("/rides");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        List<Ride?> rides = JsonSerializer.Deserialize<List<Ride?>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        
        foreach (var ride in rides)
        {
            if (ride.Id == id)
            {
                return ride;
            }
        }

        throw new ArgumentException();
    }
    
    

    public async Task JoinRide(JoinRideDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/rides", dto);
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
        
    }
}