using GestionInventario.Models;
using GestionInventario.Models.Dto;
using System.Runtime.CompilerServices;

namespace GestionInventario.Services.Interfaces;

public interface ISupplierService

{
    Task<bool> CreateSupplier(SupplierDto supplierDto);

    Task<List<Supplier>> GetAllSuppliers();

    Task<bool> ExistsSupplierById(int id);

    Task<bool> UpdateSupplier(string nit, SupplierUpdateDto updatedSupplierDto);

    Task<bool> Update();

    Task<Supplier?> GetSupplierById(int id);
    Task<bool> UpdateSupplierStatus(string nit);
}
