using PawPoint.Infraestructure.Models;

namespace PawPoint.Infraestructure.Interfaces;

public interface IPetInfraestructure
{
    Task<Pet?> GetPetByIdAsync(int id);
    Task<List<Pet>> GetPetsAsync();
    Task<bool> CreatePetAsync(Pet pet);
    Task<bool> UpdatePetAsync(int id,Pet pet);
    Task<bool> DeletePetAsync(int id);
    Task<List<Meeting>>GetMeetingsByPetId(int id);
    
    
}