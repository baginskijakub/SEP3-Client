namespace Domain.Models;

public class Driver
{
    private string name { get; set; }
    private Task <List<Ride>> rides { get; set; }
}
