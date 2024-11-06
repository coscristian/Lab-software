using GestionInventario.Models;
using GestionInventario.Models.Dto;
using System.Runtime.CompilerServices;

namespace GestionInventario.Services.Interfaces;

public interface ISupplierService

{
    Task<bool> CreateSupplier(ProductDto product);

    Task<List<Supplier>> GetAllSupplier();

    Task<bool> ExistsSupplierById(int id);

    Task<bool> UpdateSupplier(int id, SupplierUpdateDto  updatedSupplierDto);

    Task<bool> Update();

    Task<Supplier?> GetSupplierById(int id);

    Task<bool> UpdateSupplierStatus(int id);




}
