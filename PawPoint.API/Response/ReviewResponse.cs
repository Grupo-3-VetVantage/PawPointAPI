namespace PawPoint.API.Response;

public class ReviewResponse
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public int Rating { get; set; }
    public int UserId { get; set; }
    public int VeterinaryId { get; set; }
}