using Microsoft.EntityFrameworkCore;
using PawPoint.Infraestructure.Context;
using PawPoint.Infraestructure.Interfaces;
using PawPoint.Infraestructure.Models;

namespace PawPoint.Infraestructure;

public class ServiceInfraestructure:IServiceInfraestructure
{
    private readonly VetDbContext _VetDBContext;
    public ServiceInfraestructure(VetDbContext context)
    {
        _VetDBContext = context;
    }
    
    public async Task<bool> CreateServiceAsync(Service service)
    {
        try
        {
            service.IsActive = true;
            _VetDBContext.Services.Add(service);
            await _VetDBContext.SaveChangesAsync();
            return true;
        }
        catch (Exception exception) { return false; }
    }

    public async Task<bool> UpdateServiceAsync(int id,Service service)
    {
        try
        {
            var serviceFound =  _VetDBContext.Services.Find(id);
            serviceFound.DateUpdated = DateTime.Now;
            serviceFound.Name = service.Name;
            serviceFound.Description = service.Description;
            serviceFound.Price = service.Price;
            serviceFound.ImgUrl = service.ImgUrl;
            _VetDBContext.Services.Update(serviceFound);
            await _VetDBContext.SaveChangesAsync();
            return true;

        }
        catch (Exception e)
        {return false;}
    }

    public async Task<bool> DeleteServiceAsync(int id)
    {
        var serviceFound = _VetDBContext.Services.Find(id);
        serviceFound!.IsActive = false;
        _VetDBContext.Services.Update(serviceFound);
        await _VetDBContext.SaveChangesAsync();
        return true;
    }

    public async Task<Service?> GetServiceByIdAsync(int id)
    {
        return await _VetDBContext.Services.FirstOrDefaultAsync(service => service.Id == id);
    }

    public async Task<List<Service>> GetAllServicesAsync()
    {
        return await _VetDBContext.Services.ToListAsync();
    }
}