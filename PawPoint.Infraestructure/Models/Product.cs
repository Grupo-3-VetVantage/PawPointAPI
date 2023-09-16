namespace PawPoint.Infraestructure.Models;

public class Product:BaseModel
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public bool Stock { get; set; }
    public string ImgUrl { get; set; } = string.Empty;
    public int VeterinaryId { get; set; }
    public Veterinary Veterinary { get; set; } = null!;
    
 
    
}