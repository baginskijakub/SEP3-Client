namespace Domain.Models;

public class Location
{
    public string Country { get; set; }
    public string City { get; set; }
    public string StreetName { get; set; }
<<<<<<< HEAD
    public int ZipCode { get; set; }
=======
    public string ZipCode { get; set; }
>>>>>>> 9377c377bd76b5d36a5e260c7978fc3642f4f8b5
    public long CoordinatesX { get; set; }
    public long CoordinatesY { get; set; }
}