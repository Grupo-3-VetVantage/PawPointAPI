using Microsoft.EntityFrameworkCore;
using PawPoint.Infraestructure.Context;
using PawPoint.Infraestructure.Interfaces;
using PawPoint.Infraestructure.Models;

namespace PawPoint.Infraestructure;

public class VeterinaryInfraestructure:IVeterinaryInfraestructure
{
    private readonly VetDbContext _VetDBContext;
    public VeterinaryInfraestructure(VetDbContext context)
    {
        _VetDBContext = context;
    }
    
    public async Task<List<Veterinary>> GetAll()
    {
        return await _VetDBContext.Veterinaries.ToListAsync();
        
    }

    public async Task<bool> CreateVeterinary(Veterinary veterinary)
    {
    
            try
            {
                veterinary.IsActive = true;
                _VetDBContext.Veterinaries.Add(veterinary);
                await _VetDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception exception) { return false; }
        
    }

    public async Task<Veterinary?> GetById(int id)
    {
        return await _VetDBContext.Veterinaries.FirstOrDefaultAsync(vet => vet.Id == id);    
    }

    public async Task<bool> UpdateVeterinary(int id, Veterinary veterinary)
    {
        try
        {
            var vetyFound =  _VetDBContext.Veterinaries.Find(id);
            vetyFound!.DateUpdated = DateTime.Now;
            vetyFound.Name = veterinary.Name;
            vetyFound.LastName = veterinary.LastName;
            vetyFound.Speciality = veterinary.Speciality;
            vetyFound.Address = veterinary.Address;
            vetyFound.Phone = veterinary.Phone;
            vetyFound.Email = veterinary.Email;
            vetyFound.Description = veterinary.Description;
            vetyFound.ImgUrl = veterinary.ImgUrl;
            _VetDBContext.Veterinaries.Update(vetyFound);
            await _VetDBContext.SaveChangesAsync();
            return true;

        }
        catch (Exception e)
        {return false;}
    }

    public async Task<bool> DeleteVeterinary(int id)
    {
        var vetyFound = _VetDBContext.Veterinaries.Find(id);
        vetyFound!.IsActive = false;

        _VetDBContext.Veterinaries.Update(vetyFound);
        await _VetDBContext.SaveChangesAsync();
        return true;
    }

    public async Task<Veterinary?> GetVeterinaryLogin(string email, string password)
    {
        return await _VetDBContext.Veterinaries.FirstOrDefaultAsync(vet => vet.Email == email && vet.Password == password);
    }

    public async Task<int> Signup(Veterinary veterinary)
    {
        veterinary.DateCreated = DateTime.Now;
        veterinary.IsActive = true;
        _VetDBContext.Veterinaries.Add(veterinary);
        await _VetDBContext.SaveChangesAsync();
        return veterinary.Id;
    }

    public async Task<List<Service>> GetServicesByVeterinaryId(int id)
    {
        return await _VetDBContext.Services.Where(service => service.VeterinaryId == id).ToListAsync();
    }

    public async Task<List<Meeting>> GetMeetingsByVeterinaryId(int meetingId)
    {
        return await _VetDBContext.Meetings.Where(meeting => meeting.VetId == meetingId).ToListAsync();
    }

    public async Task<List<Product>> GetProductsByVeterinaryId(int productId)
    {
        return await _VetDBContext.Products.Where(product => product.VeterinaryId == productId).ToListAsync();
    }

    public async Task<List<Review>> GetReviewsByVeterinaryId(int reviewId)
    {
        return await _VetDBContext.Reviews.Where(review => review.VeterinaryId == reviewId).ToListAsync();
    }

  
}