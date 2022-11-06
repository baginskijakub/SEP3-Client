namespace HttpClients.ClientInterfaces;

public interface IRideService
{
    Task<List<Ride?>> GetAllRidesAsync();

    Task JoinRide(JoinRideDto dto);
}