namespace Domain.Models;

public class Reservation
{
    public string PassengerName { get; set; }
    
    public int RideId { get; set; }
    
    public int ReservationId { get; set; }
    
    public bool? IsAccepted { get; set; }
    
    public string Status { get; set; }

}