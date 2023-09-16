namespace PawPoint.API.Response;

public class ServiceResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Duration { get; set; }
    public int VeterinaryId { get; set; }
    public string ImgUrl { get; set; } = string.Empty;
}