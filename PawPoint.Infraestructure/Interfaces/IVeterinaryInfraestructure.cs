using PawPoint.Infraestructure.Models;

namespace PawPoint.Infraestructure.Interfaces;

public interface IVeterinaryInfraestructure
{
    
    Task<List<Veterinary>> GetAll();
    Task<bool> CreateVeterinary(Veterinary veterinary);
    Task<Veterinary?> GetById(int id);
    Task<bool> UpdateVeterinary(int id, Veterinary veterinary);
    Task<bool> DeleteVeterinary(int id);
    Task<Veterinary?> GetVeterinaryLogin(string email, string password);
    Task<int> Signup(Veterinary veterinary);


    Task<List<Meeting>>GetMeetingsByVeterinaryId(int id);
    Task<List<Product>>GetProductsByVeterinaryId(int id);
    Task<List<Review>>GetReviewsByVeterinaryId(int id);
    Task<List<Service>>GetServicesByVeterinaryId(int id);
    
}