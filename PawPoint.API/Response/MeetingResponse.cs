namespace PawPoint.API.Response;

public class MeetingResponse
{
    public int Id { get; set; }
    public DateOnly DateToMeet { get; set; }
    public bool Finish { get; set; }
    public string Description { get; set; } = string.Empty;
    public int VetId { get; set; }
    public int UserId { get; set; }
    public int PetId { get; set; }
}