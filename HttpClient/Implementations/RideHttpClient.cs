using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading.Tasks;
using Domain.DTOs;
using Domain.Models;
using HttpClients.ClientInterfaces;
using DateTime = System.DateTime;

namespace HttpClients.Implementations;

public class RideHttpClient : IRideService
{
    private readonly HttpClient client;

    public RideHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<List<Ride>> GetAllRidesAsync(string? startDate, string? endDate)
    {
        string query = "";
        if (String.IsNullOrEmpty(startDate) && !String.IsNullOrEmpty(endDate))
        {
            DateTime today = DateTime.Now;
            string todayString = today.ToString("dd/MM/yyyy");
            todayString = todayString.Replace(".", "/");

            query = $"?startDate={todayString}&endDate={endDate}";
        }

        if (!String.IsNullOrEmpty(endDate) && !String.IsNullOrEmpty(startDate))
        {
            query = $"?startDate={startDate}&endDate={endDate}";

        }
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7013/rides{query}");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        List<Ride> rides = JsonSerializer.Deserialize<List<Ride>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return rides;
    }
    
    public async Task<Ride?> GetRideById(int id)
    {
        HttpResponseMessage response = await client.GetAsync("https://localhost:7013/rides");
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
                Console.WriteLine("es");
                return ride;
            }
        }

        throw new ArgumentException();
    }
    
    

    public async Task JoinRide(JoinRideDto dto)
    {
        
        HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:7013/rides", dto);
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode || content.Contains("There is no"))
        {
            Console.WriteLine(content);
            throw new Exception(content);
        }

        
    }
    
    public async Task<Ride> CreateRide(RideCreationDto creationDto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:7013/rides/create", creationDto);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine(result);
            throw new Exception(result);
        }

        Ride? ride = JsonSerializer.Deserialize<Ride>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return ride!;
    }

    public async Task<List<Ride>> GetRidesByDriverId(int driverId)
    {
        //endpoint to be changed as it uses same as GetAllRidesAsync, dependent on controller implementation
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7013/rides/{driverId}");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        List<Ride> rides = JsonSerializer.Deserialize<List<Ride>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return rides;
    }
}