using GestionInventario.Models;
using GestionInventario.Models.Dto;
using System.Runtime.CompilerServices;

namespace GestionInventario.Services.Interfaces;

public interface IProductService
{
    Task<bool> CreateProduct(ProductDto product);
    Task<List<Product>> GetAllProducts();
    
    Task<bool> ExistsProductById(int id);

    Task<bool> UpdateProduct(int id , ProductDto productUpd);

    Task<Product?> GetProductById(int id);

    Task<bool> DeleteProduct( int id);
}