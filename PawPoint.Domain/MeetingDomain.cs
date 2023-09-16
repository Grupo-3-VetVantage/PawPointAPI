using PawPoint.Domain.Interfaces;
using PawPoint.Infraestructure.Interfaces;
using PawPoint.Infraestructure.Models;

namespace PawPoint.Domain;

public class MeetingDomain:IMeetingDomain
{
    private readonly IMeetingInfraestructure _meetingInfraestructure;
    public MeetingDomain(IMeetingInfraestructure meetingInfraestructure)
    {
        _meetingInfraestructure = meetingInfraestructure;
    }

    public async Task<bool> CreateMeetingAsync(Meeting meeting)
    {
        return await _meetingInfraestructure.CreateMeetingAsync(meeting);
    }

    public async Task<bool> FinishMeeting(int id, bool finish)
    {
        return await _meetingInfraestructure.FinishMeeting(id, finish);
    }

    public async Task<Meeting?> GetMeetingAsyncById(int id)
    {
        return await _meetingInfraestructure.GetMeetingAsyncById(id);
    }

    public async Task<List<Meeting>> GetMeetingsAsync()
    {
        return await _meetingInfraestructure.GetMeetingsAsync();
    }

    public async Task<bool> UpdateMeetingAsync(int id,Meeting meeting)
    {
        return await _meetingInfraestructure.UpdateMeetingAsync(id,meeting);
    }

    public async Task<bool> DeleteMeetingAsync(int id)
    {
        return await _meetingInfraestructure.DeleteMeetingAsync(id);
    }

    public async Task<IEnumerable<Meeting>> GetAllMeetingByUserIdAsync(int userId)
    {
        return await _meetingInfraestructure.GetAllMeetingByUserIdAsync(userId);
    }

    public async Task<IEnumerable<Meeting>> GetAllMeetingByVeterinaryIdAsync(int veterinaryId)
    {
        return await _meetingInfraestructure.GetAllMeetingByVeterinaryIdAsync(veterinaryId);
    }
}