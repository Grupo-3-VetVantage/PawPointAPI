namespace PawPoint.API.Input;

public class MeetingCreateInput
{
    public DateOnly DateToMeet { get; set; }
    public bool Finish { get; set; } = false;
    public string Description { get; set; } = string.Empty;
    public int VetId { get; set; }
    public int UserId { get; set; }

}