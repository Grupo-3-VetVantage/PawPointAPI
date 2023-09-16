using PawPoint.Infraestructure.Models;

namespace PawPoint.Domain.Interfaces;

public interface IProductDomain
{
    Task<List<Product>> GetProductsAsync();
    Task<Product?> GetProductByIdAsync(int id);
    Task<bool> CreateProductAsync(Product product);
    Task<bool> UpdateProductAsync(int id,Product product);
    Task<bool> DeleteProductAsync(int id);
    
}