using Microsoft.EntityFrameworkCore;
using PawPoint.Infraestructure.Context;
using PawPoint.Infraestructure.Interfaces;
using PawPoint.Infraestructure.Models;

namespace PawPoint.Infraestructure;

public class ProductInfraestructure:IProductInfraestructure
{
    private readonly VetDbContext _VetDBContext;
    public ProductInfraestructure(VetDbContext context)
    {
        _VetDBContext = context;
    }
    
    public async Task<List<Product>> GetProductsAsync()
    {
        return await _VetDBContext.Products.ToListAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _VetDBContext.Products.FirstOrDefaultAsync(product => product.Id == id);
    }

    public async Task<bool> CreateProductAsync(Product product)
    {
        try
        {
            product.IsActive = true;
            product.DateCreated = DateTime.Now;
            _VetDBContext.Products.Add(product);
            await _VetDBContext.SaveChangesAsync();
            return true;
        }
        catch (Exception exception) { throw new Exception(exception.Message); }
        
    }

    public async Task<bool> UpdateProductAsync(int id,Product product)
    {
        try
        {
            var productFound =  _VetDBContext.Products.Find(id);
            productFound!.DateUpdated = DateTime.Now;
            productFound.Name = product.Name;
            productFound.Description = product.Description;
            productFound.Price = product.Price;
            productFound.Stock = product.Stock;
            productFound.ImgUrl = product.ImgUrl;
            _VetDBContext.Products.Update(productFound);
            await _VetDBContext.SaveChangesAsync();
            return true;

        }
        catch (Exception e)
        {throw new Exception(e.Message);}
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var productFound = _VetDBContext.Products.Find(id);
        productFound!.IsActive = false;
        _VetDBContext.Products.Update(productFound);
        await _VetDBContext.SaveChangesAsync();
        return true;
    }
}