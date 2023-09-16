using System.Collections.ObjectModel;
using PawPoint.Infraestructure.Models;

namespace PawPoint.Domain.Interfaces;

public interface IUserDomain
{
    Task<bool> CreateUserAsync(User user);
    Task<User?> GetById(int id);
    Task<bool> UpdateUser(int id, User user);
    Task<bool> DeleteUser(int id);
    Task<User?> GetUserLogin(string email, string password);
    Task<User> GetByUsername(string username);
    Task<int> Signup(User user);
    Task<List<Pet>?> GetPetsByUserId(int id);
    Task<List<Meeting>> GetMeetingsByUserId(int id);
    Task<List<Review>> GetReviewsByUserId(int id);
}