namespace  PawPoint.Infraestructure.Models;

public class Service:BaseModel
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Duration { get; set; }
    public int VeterinaryId { get; set; }
    public string ImgUrl { get; set; } = string.Empty;
    public Veterinary Veterinary { get; set; } = null!;
    
    
}