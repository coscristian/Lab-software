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

    public async Task<List<Product>> GetAllProducts()
    {

        return await _context.Products.ToListAsync();
    }

    public async Task<bool> UpdateProduct(Product product)
    {
        try
        {
            // Marca el objeto como modificado
            _context.Products.Update(product);

            // Guarda los cambios
            int rowsAffected = await _context.SaveChangesAsync();

            // Verifica si alguna fila fue afectada
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
        if (!await ExistsProductById(id))
        {
            return null;
        }

        return await _context.Products.FindAsync(id);
    }

    public async Task<bool>  DeleteProduct( int id)
    {
       
        var productToDelete = await _context.Products.FindAsync(id);

        _context.Products.Remove(productToDelete);
        _context.SaveChanges();

         return true;
    }
}




