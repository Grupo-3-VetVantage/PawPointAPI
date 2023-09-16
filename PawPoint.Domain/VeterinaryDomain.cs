using PawPoint.Domain.Interfaces;
using PawPoint.Infraestructure.Interfaces;
using PawPoint.Infraestructure.Models;

namespace PawPoint.Domain;

public class VeterinaryDomain:IVeterinaryDomain
{
    private readonly IVeterinaryInfraestructure _veterinaryInfraestructure;
    public VeterinaryDomain(IVeterinaryInfraestructure veterinaryInfraestructure)
    {
        _veterinaryInfraestructure = veterinaryInfraestructure;
    }

    public async Task<bool> CreateVeterinary(Veterinary veterinary)
    {
        return await _veterinaryInfraestructure.CreateVeterinary(veterinary);
    }

    public async Task<Veterinary?> GetById(int id)
    {
        return await _veterinaryInfraestructure.GetById(id);
    }

    public async Task<bool> UpdateVeterinary(int id, Veterinary veterinary)
    {
        return await _veterinaryInfraestructure.UpdateVeterinary(id, veterinary);
    }

    public async Task<bool> DeleteVeterinary(int id)
    {
        return await _veterinaryInfraestructure.DeleteVeterinary(id);
    }

    public async Task<Veterinary?> GetVeterinaryLogin(string email, string password)
    {
        return await _veterinaryInfraestructure.GetVeterinaryLogin(email, password);
    }

    public async Task<int> Signup(Veterinary veterinary)
    {
        return await _veterinaryInfraestructure.Signup(veterinary);
    }

    public async Task<List<Service>> GetServicesByVeterinaryId(int id)
    {
        return await _veterinaryInfraestructure.GetServicesByVeterinaryId(id);
    }

    public async Task<List<Meeting>> GetMeetingsByVeterinaryId(int id)
    {
        return await _veterinaryInfraestructure.GetMeetingsByVeterinaryId(id);
    }

    public async Task<List<Product>> GetProductsByVeterinaryId(int id)
    {
        return await _veterinaryInfraestructure.GetProductsByVeterinaryId(id);
    }

    public async Task<List<Review>> GetReviewsByVeterinaryId(int id)
    {
        return await _veterinaryInfraestructure.GetReviewsByVeterinaryId(id);
    }

   
}