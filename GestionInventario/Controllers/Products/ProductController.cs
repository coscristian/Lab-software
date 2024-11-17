using AutoMapper;
using ErrorOr;
using GestionInventario.Models.Dto;
using GestionInventario.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;

namespace GestionInventario.Controllers.Products;

[Route("api/[controller]")] 
public class ProductController : ApiController
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }
    
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateProduct([FromBody] ProductDto product)
    {
        var productResult = await _productService.CreateProduct(product);
        return productResult.Match(
            result => Created(Url.Action("Get"), result), // TODO: Crear endpoint para obtener con el id creado
            errors => Problem(errors)
        );
        
        
        /*return result ?
            CreatedAtAction(nameof(CreateProduct), result)
            : BadRequest("No se pudo crear el Producto");*/
    }

    [HttpGet]
    [Route("Read")]
    public async Task<ActionResult<List<ProductDto>>> Get(string? name, string? category)
    {
        var products = await _productService.GetAllProducts(name, category);
        var productsDto = _mapper.Map<List<ProductDto>>(products);
        return Ok(productsDto);
    }


    [HttpPut]
    [Route("Updates")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductUpdateDto updatedProductDto)
    {
        if (updatedProductDto == null)
        {
            return BadRequest("El cuerpo de la solicitud no puede estar vacío.");
        }

        bool isUpdated = await _productService.UpdateProduct(id, updatedProductDto);

        if (!isUpdated)
        {
            return NotFound($"No se encontró el producto con ID = {id}.");
        }

        return Ok(isUpdated);
    }

    [HttpPut]
    [Route("Delete")]

    public async Task<IActionResult> DeleteProduct(int id)
    {
        var result = await _productService.UpdateProductStatus(id);
        return result ? NoContent() : NotFound("No se eliminó, al parecer el recurso no existe");
    }

}