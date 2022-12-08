namespace Domain.Models;

public class Location
{
    public string Country { get; set; }
    public string City { get; set; }
    public string StreetName { get; set; }

    public string ZipCode { get; set; }

    public double CoordinatesX { get; set; }
    public double CoordinatesY { get; set; }

    public string Address => $"{StreetName}, {City}";
}