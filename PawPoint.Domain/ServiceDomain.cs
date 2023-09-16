using PawPoint.Domain.Interfaces;
using PawPoint.Infraestructure.Interfaces;
using PawPoint.Infraestructure.Models;

namespace PawPoint.Domain;

public class ServiceDomain:IServiceDomain
{
    private readonly IServiceInfraestructure _serviceInfraestructure;
    public ServiceDomain(IServiceInfraestructure serviceInfraestructure)
    {
        _serviceInfraestructure = serviceInfraestructure;
    }

    public async Task<bool> CreateServiceAsync(Service service)
    {
        return await _serviceInfraestructure.CreateServiceAsync(service);
    }

    public async Task<bool> UpdateServiceAsync(int id,Service service)
    { 
        return await _serviceInfraestructure.UpdateServiceAsync(id,service);
    }

    public async Task<bool> DeleteServiceAsync(int id)
    {
        return await _serviceInfraestructure.DeleteServiceAsync(id);
    }

    public async Task<Service?> GetServiceByIdAsync(int id)
    {
        return await _serviceInfraestructure.GetServiceByIdAsync(id);
    }

    public async Task<List<Service>> GetAllServicesAsync()
    {
        return await _serviceInfraestructure.GetAllServicesAsync();
    }
}