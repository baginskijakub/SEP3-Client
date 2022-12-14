using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text;
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

    public async Task<List<Ride>> GetAllRidesAsync(string? startDate, string? endDate, string userId)
    {
        Console.WriteLine(1);
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",LoginHttpClient.Jwt);

        string query = $"?userId={userId}";
        if (String.IsNullOrEmpty(startDate) && !String.IsNullOrEmpty(endDate))
        {
            DateTime today = DateTime.Now;
            string todayString = today.ToString("dd/MM/yyyy");
            todayString = todayString.Replace(".", "/");

            query += $"&startDate={todayString}&endDate={endDate}";
        }

        if (!String.IsNullOrEmpty(endDate) && !String.IsNullOrEmpty(startDate))
        {
            query += $"&startDate={startDate}&endDate={endDate}";

        }

        Console.WriteLine(query);
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
    {        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",LoginHttpClient.Jwt);

        HttpResponseMessage response = await client.GetAsync($"https://localhost:7013/rides/{id}");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        Ride ride = JsonSerializer.Deserialize<Ride?>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        return ride;
    }
    
    

    public async Task JoinRide(JoinRideDto dto)
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",LoginHttpClient.Jwt);
        HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:7013/rides/reservation", dto);
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode || content.Contains("There is no"))
        {
            Console.WriteLine(content);
            throw new Exception(content);
        }

        
    }
    
    public async Task<Ride> CreateRide(RideCreationDto creationDto)
    {
        
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",LoginHttpClient.Jwt);

        HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:7013/rides", creationDto);
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
        
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",LoginHttpClient.Jwt);

        HttpResponseMessage response = await client.GetAsync($"https://localhost:7013/rides/driver/{driverId}");
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

    public async Task<bool> ChangeRideStatus(ChangeStatusDto dto)
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",LoginHttpClient.Jwt);
        
        
        string jsonDto = JsonSerializer.Serialize(dto);
        StringContent content = new(jsonDto, Encoding.UTF8, "application/json");
        
        HttpResponseMessage response = await client.PatchAsync($"https://localhost:7013/rides/", content);
        string result = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine(result);
            throw new Exception(result);
        }

        return true;
    }
}