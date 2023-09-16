using PawPoint.Domain.Interfaces;
using PawPoint.Infraestructure.Interfaces;
using PawPoint.Infraestructure.Models;

namespace PawPoint.Domain;

public class ProductDomain:IProductDomain
{
    private readonly IProductInfraestructure _productInfraestructure;
    public ProductDomain(IProductInfraestructure productInfraestructure)
    {
        _productInfraestructure = productInfraestructure;
    }


    public async Task<List<Product>> GetProductsAsync()
    {
        return await _productInfraestructure.GetProductsAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _productInfraestructure.GetProductByIdAsync(id);
    }

    public async Task<bool> CreateProductAsync(Product product)
    {
        return await _productInfraestructure.CreateProductAsync(product);
    }

    public async Task<bool> UpdateProductAsync(int id,Product product)
    {
        return await _productInfraestructure.UpdateProductAsync(id,product);
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        return await _productInfraestructure.DeleteProductAsync(id);
    }
}