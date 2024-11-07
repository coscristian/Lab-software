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
            var result = await _supplierService.CreateSupplier(supplierDto);
            return result ?
                CreatedAtAction(nameof(CreateSupplier), result)
                : BadRequest("No se pudo crear el Proveedor");
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
            return result ? NoContent() : NotFound("No se actualizó, al parecer el recurso no existe");
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteSupplier(string nit)
        {
            var result = await _supplierService.UpdateSupplierStatus(nit);
            return result ? NoContent() : NotFound("No se eliminó, al parecer el recurso no existe");
        }
    }
}
