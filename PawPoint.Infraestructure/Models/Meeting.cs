namespace  PawPoint.Infraestructure.Models;

public class Meeting:BaseModel
{
    public DateOnly DateToMeet { get; set; }
    public bool Finish { get; set; }
    public string Description { get; set; } = string.Empty;
    public int VetId { get; set; }
    public Veterinary Veterinary { get; set; } = null!;
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public int PetId { get; set; }
    public Pet Pet { get; set; } = null!;
    
    
}