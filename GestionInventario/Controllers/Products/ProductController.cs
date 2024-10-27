using GestionInventario.Models.Dto;
using GestionInventario.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestionInventario.Controllers.Products;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateProduct([FromBody] ProductDto product)
    {
        var result = await _productService.CreateProduct(product);
        return Ok(result);
    }
}