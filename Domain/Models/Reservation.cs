namespace Domain.Models;

public class Reservation
{
    public string passengerName { get; set; }
    
    public int rideId { get; set; }
    
    public int reservationId { get; set; }
    
    public bool? isAccepted { get; set; }
}