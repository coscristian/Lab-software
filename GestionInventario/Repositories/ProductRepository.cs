using GestionInventario.Models;
using GestionInventario.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;

namespace GestionInventario.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly MyDbContext _context;

    public ProductRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Add(Product product)
    {
        var result = await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> ExistsProductById(int id)
    {
        return await _context.Products.AnyAsync(p => p.Id == id);
    }

    public async Task<bool> ExistsProductByBarCodeAsync(string barCode)
    {
        return await _context.Products.AnyAsync(p => p.BarCode == barCode);
    }

    public async Task<List<Product>> GetAllProducts(string? name, string? category)
    {
        return await _context.Products
                .Where(p => p.Status &&
                            (string.IsNullOrEmpty(name) || p.Name.Contains(name)) &&
                            (string.IsNullOrEmpty(category) || p.Category.Contains(category)))
                .ToListAsync();
    }

    public async Task<bool> UpdateProduct(Product product)
    {
        try
        {
            
            _context.Products.Update(product);

         
            int rowsAffected = await _context.SaveChangesAsync();

            
            return rowsAffected > 0;
        }
        catch (Exception)
        {
            // Manejo de excepciones, devuelve false en caso de error
            
            return false;
        }
    }

    public async Task<Product?> GetProductById(int id)
    {
        return await _context.Products
            .Where(p => p.Status && p.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<bool>  DeleteProduct( int id)
    {
       
        var productToDelete = await _context.Products.FindAsync(id);

        _context.Products.Remove(productToDelete);
        _context.SaveChanges();

         return true;
    }
}




