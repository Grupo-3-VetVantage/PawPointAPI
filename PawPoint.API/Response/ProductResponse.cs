namespace PawPoint.API.Response;

public class ProductResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public bool Stock { get; set; }
    public string ImgUrl { get; set; } = string.Empty;
    public int VeterinaryId { get; set; }
}