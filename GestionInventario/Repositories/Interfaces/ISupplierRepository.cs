using GestionInventario.Models;
using Microsoft.EntityFrameworkCore;



namespace GestionInventario.Repositories.Interfaces;


public interface ISupplierRepository
{

    Task<bool> Add(Supplier supplier);
    Task<bool> ExistsSupplierById(int id);
   
    Task<List<Supplier>> GetAllProducts();

    Task<bool> UpdateSupplier(Supplier supplier);

    Task<Supplier?> GetSuppliertById(int id);

    Task<bool> DeleteSupplier(int id);

}