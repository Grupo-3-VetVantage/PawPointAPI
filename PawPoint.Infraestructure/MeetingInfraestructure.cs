using Microsoft.EntityFrameworkCore;
using PawPoint.Infraestructure.Context;
using PawPoint.Infraestructure.Interfaces;
using PawPoint.Infraestructure.Models;

namespace PawPoint.Infraestructure;

public class MeetingInfraestructure:IMeetingInfraestructure
{
    private readonly VetDbContext _VetDBContext;
    public MeetingInfraestructure(VetDbContext context)
    {
        _VetDBContext = context;
    }

    public async Task<bool> CreateMeetingAsync(Meeting meeting)
    {
        try
        {
            meeting.IsActive = true;
            _VetDBContext.Meetings.Add(meeting);
            await _VetDBContext.SaveChangesAsync();
            return true;
        }
        catch (Exception exception) { throw new Exception(exception.Message); }
    }

    public async Task<Meeting?> GetMeetingAsyncById(int id)
    {
        return await _VetDBContext.Meetings.FindAsync(id);
    }

    public async Task<List<Meeting>> GetMeetingsAsync()
    {
        return await _VetDBContext.Meetings.ToListAsync();
    }

    public async Task<bool> UpdateMeetingAsync(int id,Meeting meeting)
    {
        try
        {
            var meetingFound =  _VetDBContext.Meetings.Find(id);
            meetingFound!.DateUpdated = DateTime.Now;
            meetingFound.DateToMeet = meeting.DateToMeet;
            meetingFound.Description = meeting.Description;
            meetingFound.Finish = meeting.Finish;
            meetingFound.UserId = meeting.UserId;
            meetingFound.VetId = meeting.VetId;
            _VetDBContext.Meetings.Update(meetingFound);
            await _VetDBContext.SaveChangesAsync();
            return true;

        }
        catch (Exception e)
        {throw new Exception(e.Message);}
    }

    public async Task<bool> DeleteMeetingAsync(int id)
    {
        try
        {
            var meetingFound =  _VetDBContext.Meetings.Find(id);
            meetingFound!.IsActive = false;
            _VetDBContext.Meetings.Update(meetingFound);
            await _VetDBContext.SaveChangesAsync();
            return true;

        }
        catch (Exception e)
        {throw new Exception(e.Message);}
    }

    public async Task<IEnumerable<Meeting>?> GetAllMeetingByUserIdAsync(int userId)
    {
        return await _VetDBContext.Meetings.Where(meeting => meeting.UserId == userId).ToListAsync();
    }

    public async Task<IEnumerable<Meeting>?> GetAllMeetingByVeterinaryIdAsync(int veterinaryId)
    {
        return await _VetDBContext.Meetings.Where(meeting => meeting.VetId == veterinaryId).ToListAsync();
    }

    public Task<bool> CreateMeetingAsync(int id, Meeting meeting)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> FinishMeeting(int id, bool finish)
    {
        var findMeeting = await _VetDBContext.Meetings.FindAsync(id);
        if (findMeeting == null) return false;
        findMeeting.Finish = finish;
        _VetDBContext.Meetings.Update(findMeeting);
        await _VetDBContext.SaveChangesAsync();
        return true;
    }
}