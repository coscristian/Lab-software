using AutoMapper;
using GestionInventario.Models.Dto;
using GestionInventario.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;

namespace GestionInventario.Controllers.Products;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
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
        var result = await _productService.CreateProduct(product);
        return Ok(result);
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
        // Validar si el DTO es nulo
        if (updatedProductDto == null)
        {
            return BadRequest("El cuerpo de la solicitud no puede estar vacío.");
        }

        // Intentar actualizar el producto
        bool isUpdated = await _productService.UpdateProduct(id, updatedProductDto);

        // Si no se encontró el producto, devolver NotFound
        if (!isUpdated)
        {
            return NotFound($"No se encontró el producto con ID = {id}.");
        }

        // Si la actualización fue exitosa, devolver NoContent
        return Ok(isUpdated);
    }



    [HttpPut]
    [Route("Delete")]

    public async Task<IActionResult> DeleteProduct(int id)
    {
        var result = await _productService.UpdateProductStatus(id);
        return Ok(result);
    }

}