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

    public async Task<bool> CreateSupplier(SupplierDto supplierDto)
    {
        var supplier = await _supplierRepository.GetSuppliertByNit(supplierDto.Nit);

        if(supplier != null)
        {
            return false;
        }

        var mappedSupplier = _mapper.Map<SupplierDto, Supplier>(supplierDto);
        mappedSupplier.Status = true;
        mappedSupplier.CreationDate = DateTime.Now;
        mappedSupplier.ModificationDate = DateTime.Now;
        mappedSupplier.MotivoEstado = string.Empty;

        var result = await _supplierRepository.Add(mappedSupplier);
        return result;
    }

    public async Task<bool> ExistsSupplierById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Supplier>> GetAllSuppliers()
    {
        return await _supplierRepository.GetAllSuppliers();
    }

    public async Task<Supplier?> GetSupplierById(int id)
    {
        return await _supplierRepository.GetSuppliertById(id);
    }

    public async Task<bool> Update()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateSupplier(string nit, SupplierUpdateDto updatedSupplierDto)
    {
        var existingsupplier = await _supplierRepository.GetSuppliertByNit(nit);
        if (existingsupplier == null)
        {
            return false;
        }

        existingsupplier.ModificationDate = DateTime.Now;
        existingsupplier.Address = updatedSupplierDto.Address;
        existingsupplier.Phone = updatedSupplierDto.Phone;

        return await _supplierRepository.UpdateSupplier(existingsupplier);
    }

    public async Task<bool> UpdateSupplierStatus(string nit)
    {
        var existingsupplier = await _supplierRepository.GetSuppliertByNit(nit);
        if (existingsupplier == null)
        {
            return false;
        }

        existingsupplier.Status = false;
        return await _supplierRepository.UpdateSupplier(existingsupplier);
    }
}