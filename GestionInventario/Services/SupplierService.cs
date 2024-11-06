using AutoMapper;
using GestionInventario.Controllers.Products;
using GestionInventario.Models;
using GestionInventario.Models.Dto;
using GestionInventario.Models.Enums;
using GestionInventario.Repositories.Interfaces;
using GestionInventario.Services.Interfaces;
using System.Runtime.CompilerServices;

namespace GestionInventario.Services;


public class SupplierService : ISupplierService

{
    private readonly ISupplierRepository _supplierRepository;
    private readonly IMapper _mapper;

    
    
    public SupplierService(ISupplierRepository supplierRepository, IMapper mapper)
    {
        _supplierRepository = supplierRepository;
        _mapper = mapper;
    }

    public async Task<bool> CreateSupplier(ProductDto product)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ExistsSupplierById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Supplier>> GetAllSupplier()
    {
        throw new NotImplementedException();
    }

    public async Task<Supplier?> GetSupplierById(int id)
    {
        return await _supplierRepository.GetSuppliertById(id);
    }

    public async Task<bool> Update()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateSupplier(int id, SupplierUpdateDto updatedSupplierDto)
    {
       // Obtener el producto existente del repositorio
         Supplier? existingsupplier = await _supplierRepository.GetSuppliertById(id);

        // Si el producto no existe, retorna false
        if (existingsupplier == null)
        {
            return false;
        }
    }

    public async Task<bool> UpdateSupplierStatus(int id)
    {
        throw new NotImplementedException();
    }
}