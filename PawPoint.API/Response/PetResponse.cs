namespace PawPoint.API.Response;

public class PetResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Color { get; set; } = string.Empty;
    public double Weight { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string Description { get; set; } = string.Empty;
    public string ImgUrl { get; set; } = string.Empty;
    public string Sex { get; set; } = string.Empty;
     
    public string Breed { get; set; } = string.Empty;
     
    public string Specie { get; set; } = string.Empty;
    public int OwnerId { get; set; }
}