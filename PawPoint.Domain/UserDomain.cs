using System.Collections.ObjectModel;
using PawPoint.Domain.Interfaces;
using PawPoint.Infraestructure.Context;
using PawPoint.Infraestructure.Interfaces;
using PawPoint.Infraestructure.Models;

namespace PawPoint.Domain;

public class UserDomain:IUserDomain
{
    private readonly IUserInfraestructure _userInfraestructure;
    public UserDomain(IUserInfraestructure userInfraestructure)
    {
        _userInfraestructure = userInfraestructure;
    }


    public async Task<bool> CreateUserAsync(User user)
    {
        return await _userInfraestructure.CreateUserAsync(user);
    }

    public async Task<User?> GetById(int id)
    {
        return await _userInfraestructure.GetById(id);
    }

    public async Task<bool> UpdateUser(int id, User user)
    {
        return await _userInfraestructure.UpdateUser(id, user);
    }

    public async Task<bool> DeleteUser(int id)
    {
        return await _userInfraestructure.DeleteUser(id);
    }

    public async Task<User?> GetUserLogin(string email, string password)
    {
        return await _userInfraestructure.GetUserLogin(email, password);
    }

    public async Task<User> GetByUsername(string username)
    {
        return await _userInfraestructure.GetByUsername(username);
    }

    public async Task<int> Signup(User user)
    {
        return await _userInfraestructure.Signup(user);
    }

    public async Task<List<Pet>?> GetPetsByUserId(int id)
    {
        return await _userInfraestructure.GetPetsByUserId(id);
        
    }

    public async Task<List<Meeting>> GetMeetingsByUserId(int id)
    {
        return await _userInfraestructure.GetMeetingsByUserId(id);
    }

    public async Task<List<Review>> GetReviewsByUserId(int id)
    {
        return await _userInfraestructure.GetReviewsByUserId(id);
    }
}