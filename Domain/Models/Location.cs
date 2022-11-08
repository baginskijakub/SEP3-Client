namespace Domain.Models;

public class Location
{
    public string country { get; set; }
    public string city { get; set; }
    public string streetName { get; set; }
    public int zipCode { get; set; }
    public long coordinatesX { get; set; }
    public long coordinatesY { get; set; }
}