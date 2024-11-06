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
        public async Task<IActionResult> CreateSupplier()
        {
           
            return Ok("Proveedor creado");
        }

        [HttpGet]
        [Route("Read")]
        public async Task<IActionResult> ReadSupplier()
        {
            
            return Ok("Proveedores le�dos");
        }

        [HttpPut]
        [Route("Updates")]
        public async Task<IActionResult> UpdatesSupplier()
        {
            
            return Ok("Proveedor actualizado");
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult>  DeleteSupplier(int id)
        {
            
            return Ok("Proveedor eliminado");
        }
    }
}
