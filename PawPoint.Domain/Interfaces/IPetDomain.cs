using PawPoint.Infraestructure.Models;

namespace PawPoint.Domain.Interfaces;

public interface IPetDomain
{
    Task<Pet?> GetPetByIdAsync(int id);
    Task<List<Pet>> GetPetsAsync();
    Task<bool> CreatePetAsync(Pet pet);
    Task<bool> UpdatePetAsync(int id,Pet pet);
    Task<bool> DeletePetAsync(int id);
}