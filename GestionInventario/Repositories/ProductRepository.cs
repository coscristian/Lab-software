using GestionInventario.Models;
using GestionInventario.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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
}