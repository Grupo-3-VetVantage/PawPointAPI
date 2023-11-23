using Microsoft.EntityFrameworkCore;
using PawPoint.Infraestructure.Context;
using PawPoint.Infraestructure.Interfaces;
using PawPoint.Infraestructure.Models;

namespace PawPoint.Infraestructure;

public class PetInfraestructure:IPetInfraestructure
{
    private readonly VetDbContext _VetDBContext;
    public PetInfraestructure(VetDbContext context)
    {
        _VetDBContext = context;
    }


    public async Task<Pet?> GetPetByIdAsync(int id)
    {
        return await _VetDBContext.Pets.FirstOrDefaultAsync(pet => pet.Id == id);
    }

    public async Task<List<Pet>> GetPetsAsync()
    {
        return await _VetDBContext.Pets.ToListAsync();
    }

    public async Task<bool> CreatePetAsync(Pet pet)
    {
        try
        {
            pet.IsActive = true;
            _VetDBContext.Pets.Add(pet);
            await _VetDBContext.SaveChangesAsync();
            return true;
        }
        catch (Exception exception) { throw new Exception(exception.Message); }
    }

    public async Task<bool> UpdatePetAsync(int id,Pet pet)
    {
        try
        {
            var petFound =  _VetDBContext.Pets.Find(id);
            petFound!.DateUpdated = DateTime.Now;
            petFound.Name = pet.Name;
            petFound.Age = pet.Age;
            petFound.Sex = pet.Sex;
            petFound.Breed = pet.Breed;
            petFound.Specie = pet.Specie;
            petFound.Weight = pet.Weight;
            petFound.Description = pet.Description;
            petFound.ImgUrl = pet.ImgUrl;
            _VetDBContext.Pets.Update(petFound);
            await _VetDBContext.SaveChangesAsync();
            return true;

        }
        catch (Exception e)
        {throw new Exception(e.Message);}
    }

    public async Task<bool> DeletePetAsync(int id)
    {
        var petFound = _VetDBContext.Pets.Find(id);
        petFound!.IsActive = false;
        _VetDBContext.Pets.Update(petFound);
        await _VetDBContext.SaveChangesAsync();
        return true;
    }
    public async Task<List<Meeting>> GetMeetingsByPetId(int meetingId)
    {
        return await _VetDBContext.Meetings.Where(meeting => meeting.PetId == meetingId).ToListAsync();
    }
}