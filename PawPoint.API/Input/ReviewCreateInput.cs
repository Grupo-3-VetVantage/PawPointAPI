namespace PawPoint.API.Input;

public class ReviewCreateInput
{
    public string Description { get; set; } = string.Empty;
    public int Rating { get; set; }
    public int UserId { get; set; }
    public int VeterinaryId { get; set; }
}