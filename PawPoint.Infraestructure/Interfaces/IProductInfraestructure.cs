using PawPoint.Infraestructure.Models;

namespace PawPoint.Infraestructure.Interfaces;

public interface IProductInfraestructure
{
    Task<List<Product>> GetProductsAsync();
    Task<Product?> GetProductByIdAsync(int id);
    Task<bool> CreateProductAsync(Product product);
    Task<bool> UpdateProductAsync(int id,Product product);
    Task<bool> DeleteProductAsync(int id);
    
    
}