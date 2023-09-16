using PawPoint.Infraestructure.Models;

namespace PawPoint.Infraestructure.Interfaces;

public interface IServiceInfraestructure
{
    Task<bool> CreateServiceAsync(Service service);
    Task<bool> UpdateServiceAsync(int id,Service service);
    Task<bool> DeleteServiceAsync(int id);
    Task<Service?> GetServiceByIdAsync(int id);
    Task<List<Service>> GetAllServicesAsync();
    
}