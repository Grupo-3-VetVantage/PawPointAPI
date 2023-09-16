using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using PawPoint.Infraestructure.Context;
using PawPoint.Infraestructure.Interfaces;
using PawPoint.Infraestructure.Models;

namespace PawPoint.Infraestructure;

public class UserInfraestructure:IUserInfraestructure
{
    private readonly VetDbContext _VetDBContext;
    public UserInfraestructure(VetDbContext context)
    {
        _VetDBContext = context;
    }
    
    
    public async Task<List<User>> GetAll()
    {
        return await _VetDBContext.Users.ToListAsync();
        
    }

    public async Task<bool> CreateUserAsync(User user)
    {
        
        try
        {
            user.IsActive = true;
            _VetDBContext.Users.Add(user);
            await _VetDBContext.SaveChangesAsync();
            return true;
        }
        catch (Exception exception) { return false; }
    }

    public async Task<User?> GetById(int id)
    {
        return await _VetDBContext.Users.FirstOrDefaultAsync(user => user.Id == id);    
    }

    public async Task<bool> UpdateUser(int id, User input)
    {
        try
        {
            var userFound =  _VetDBContext.Users.Find(id);
            userFound.DateUpdated = DateTime.Now;
            userFound.Email = input.Email;
            userFound.Phone = input.Phone;
            userFound.Address = input.Address;
            userFound.FirstName = input.FirstName;
            userFound.LastName = input.LastName;
            userFound.UserName = input.UserName;
            userFound.Password = input.Password;
            userFound.Roles = input.Roles;
            userFound.ImgUrl = input.ImgUrl;
            _VetDBContext.Users.Update(userFound);
            await _VetDBContext.SaveChangesAsync();
            return true;

        }
        catch (Exception e)
        {return false;}
    }

    public async Task<bool> DeleteUser(int id)
    {
        var userFound = _VetDBContext.Users.Find(id);
        userFound.IsActive = false;
        
        _VetDBContext.Users.Update(userFound);
        await _VetDBContext.SaveChangesAsync();
        return true;
    }

    public async Task<User?> GetUserLogin(string email, string password)
    {
        var user = await _VetDBContext.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        return user ?? null;
    }

    public async Task<User> GetByUsername(string username)
    {
        return await _VetDBContext.Users.SingleAsync(u => u.UserName == username);
    }

    public async Task<int> Signup(User user)
    {
        user.DateCreated = DateTime.Now;
        user.IsActive = true;
        user.Roles = "User";
        _VetDBContext.Users.Add(user);
        await _VetDBContext.SaveChangesAsync();
        return user.Id;
    }

    public async Task<List<Pet>?> GetPetsByUserId(int id)
    {
        return await _VetDBContext.Pets.Where(p => p.OwnerId == id).ToListAsync();
    }
    
    

    public async Task<List<Meeting>?> GetMeetingsByUserId(int id)
    {
        return await _VetDBContext.Meetings.Where(m => m.UserId == id).ToListAsync();
    }

    public async Task<List<Review>?> GetReviewsByUserId(int id)
    {
        return await _VetDBContext.Reviews.Where(r => r.UserId == id).ToListAsync();
    }
}