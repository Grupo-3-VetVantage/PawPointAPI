using PawPoint.Infraestructure.Models;

namespace PawPoint.Infraestructure.Interfaces;

public interface IMeetingInfraestructure
{
    Task<bool> CreateMeetingAsync(Meeting meeting);
    Task<bool> FinishMeeting(int id, bool finish);
    Task<Meeting?> GetMeetingAsyncById(int id);
    Task<List<Meeting>> GetMeetingsAsync();
    Task<bool> UpdateMeetingAsync(int id,Meeting meeting);
    Task<bool> DeleteMeetingAsync(int id);
    Task<IEnumerable<Meeting>?>GetAllMeetingByUserIdAsync(int userId);
    Task<IEnumerable<Meeting>?>GetAllMeetingByVeterinaryIdAsync(int veterinaryId);
    Task<IEnumerable<Meeting>?>GetAllMeetingByPetIdAsync(int petId);
    
}