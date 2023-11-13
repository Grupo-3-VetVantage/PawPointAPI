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
    public ICollection<MeetingResponse>? Meetings { get; set; } = new List<MeetingResponse>();
    public ICollection<ServiceResponse>? Services { get; set; } = new List<ServiceResponse>();
    public ICollection<ReviewResponse>? Reviews { get; set; } = new List<ReviewResponse>();
    public ICollection<ProductResponse>? Products { get; set; } = new List<ProductResponse>();
}