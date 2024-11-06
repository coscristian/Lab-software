using GestionInventario.Models;
using GestionInventario.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using GestionInventario.Models.Enums;
using MySqlX.XDevAPI;

namespace GestionInventario.Repositories;

public class SupplierRepository : ISupplierRepository
{

    private readonly MyDbContext _context;

    public SupplierRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Add(Supplier supplier)
    {
        await _context.Suppliers.AddAsync(supplier);
        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<bool> DeleteSupplier(int id)
    {
         var supplierToDelete = await _context.Suppliers.FindAsync(id);

        _context.Suppliers.Remove(supplierToDelete);
        _context.SaveChanges();

         return true;
    }

    public async Task<bool> ExistsSupplierById(int id)
    {
        return await _context.Suppliers.AnyAsync(p => p.Id == id);
    }

    public async Task<List<Supplier>> GetAllSuppliers()
    {
       return await _context.Suppliers.ToListAsync();
    }

    public async Task<Supplier?> GetSuppliertById(int id)
    {
         return await _context.Suppliers
            .Where(s => s.Status && s.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<Supplier?> GetSuppliertByNit(string nit)
    {
        return await _context.Suppliers
           .Where(s => s.Status && s.Nit == nit)
           .FirstOrDefaultAsync();
    }

    public async Task<bool> UpdateSupplier(Supplier supplier)
    {
        try
        {
            _context.Suppliers.Update(supplier);         
            int rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected > 0;
        }
        catch (Exception)
        {
          
            return false;
        }
    }
}
