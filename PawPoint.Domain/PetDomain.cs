using PawPoint.Domain.Interfaces;
using PawPoint.Infraestructure.Interfaces;
using PawPoint.Infraestructure.Models;

namespace PawPoint.Domain;

public class PetDomain:IPetDomain
{
    private readonly IPetInfraestructure _petInfraestructure;
    public PetDomain(IPetInfraestructure petInfraestructure)
    {
        _petInfraestructure = petInfraestructure;
    }

    public async Task<Pet?> GetPetByIdAsync(int id)
    {
        return await _petInfraestructure.GetPetByIdAsync(id);
    }

    public async  Task<List<Pet>> GetPetsAsync()
    {
        return await _petInfraestructure.GetPetsAsync();
    }

    public async Task<bool> CreatePetAsync(Pet pet)
    {
        return await _petInfraestructure.CreatePetAsync(pet);
    }

    public async Task<bool> UpdatePetAsync(int id,Pet pet)
    {
        return await _petInfraestructure.UpdatePetAsync(id,pet);
    }

    public async Task<bool> DeletePetAsync(int id)
    {
        return await _petInfraestructure.DeletePetAsync(id);
    }
    public async Task<List<Meeting>> GetMeetingsByPetId(int id)
    {
        return await _petInfraestructure.GetMeetingsByPetId(id);
    }
}