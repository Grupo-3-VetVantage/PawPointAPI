using PawPoint.Infraestructure.Models;

namespace PawPoint.API.Response;

public class VeterinaryResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Speciality { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImgUrl { get; set; } = string.Empty;
    public ICollection<Meeting>? Meetings { get; set; } = new List<Meeting>();
    public ICollection<Service>? Services { get; set; } = new List<Service>();
    public ICollection<Review>? Reviews { get; set; } = new List<Review>();
    public ICollection<Product>? Products { get; set; } = new List<Product>();
}