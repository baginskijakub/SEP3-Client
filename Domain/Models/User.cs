namespace Domain.Models;

public class User
{
    public string Name { get; set; }
    public List<Ride>? Rides { get; set; }
    public int? LicenseNumber { get; set; }
    public string Email { get; set; }
    public int Id { get; set; }
    public int Phone { get; set; }

    public User(string name, int? licenseNumber, string email, int id, int phone)
    {
        Name = name;
        LicenseNumber = licenseNumber;
        Email = email;
        Id = id;
        Phone = phone;
    }

    public User()
    {

    }
}