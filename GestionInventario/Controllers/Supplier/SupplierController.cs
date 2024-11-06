using AutoMapper;
using GestionInventario.Models.Dto;
using GestionInventario.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestionInventario.Controllers.Supplier
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;

        public SupplierController(ISupplierService supplierService, IMapper mapper)
        {
            _supplierService = supplierService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateSupplier(SupplierDto supplierDto)
        {
            var result = _supplierService.CreateSupplier(supplierDto);
            return Ok(result);
        }

        [HttpGet]
        [Route("Read")]
        public async Task<IActionResult> ReadSupplier()
        {
            var result = await _supplierService.GetAllSuppliers();
            return Ok(result);
        }

        [HttpPut]
        [Route("Updates")]
        public async Task<IActionResult> UpdatesSupplier(string nit, SupplierUpdateDto supplierUpdateDto)
        {
            var result = await _supplierService.UpdateSupplier(nit, supplierUpdateDto);
            return Ok(result);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteSupplier(string nit)
        {
            var result = await _supplierService.UpdateSupplierStatus(nit);
            return Ok(result);
        }
    }
}
