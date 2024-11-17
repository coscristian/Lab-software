using GestionInventario.Models;
using GestionInventario.Models.Dto;
using System.Runtime.CompilerServices;
using ErrorOr;
using GestionInventario.Common.Responses;
using GestionInventario.Common.Responses.Dto;

namespace GestionInventario.Services.Interfaces;

public interface IProductService
{
    Task<ErrorOr<Response<ProductResponseDto>>> CreateProduct(ProductDto product);
    Task<List<Product>> GetAllProducts(string? name, string? category);
    
    Task<bool> ExistsProductById(int id);

    Task<bool> UpdateProduct(int id , ProductUpdateDto updatedProductDto);
    Task<bool> Update(Product product);

    Task<Product?> GetProductById(int id);

    Task<bool> UpdateProductStatus(int id);
}