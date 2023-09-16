namespace PawPoint.Infraestructure.Models;

public class Review:BaseModel
{
    public string Description { get; set; } = string.Empty;
    public int Rating { get; set; }
    public int UserId { get; set; }
    public int VeterinaryId { get; set; }
    public User User { get; set; } = null!;
    public Veterinary Veterinary { get; set; } = null!;
    
}