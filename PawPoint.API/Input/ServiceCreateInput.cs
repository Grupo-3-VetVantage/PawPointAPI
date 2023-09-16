namespace PawPoint.API.Input;

public class ServiceCreateInput
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Duration { get; set; }
    public int VeterinaryId { get; set; }
    public string ImgUrl { get; set; } = string.Empty;
}