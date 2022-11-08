namespace Domain.Models;

public class Location
{
    public string Country { get; set; }
    public string City { get; set; }
    public string StreetName { get; set; }
    public int ZipCode { get; set; }
    public long CoordinatesX { get; set; }
    public long CoordinatesY { get; set; }
}